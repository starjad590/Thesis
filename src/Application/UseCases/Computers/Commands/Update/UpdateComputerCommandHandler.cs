using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Entities;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Computers.Commands.Update;

internal sealed class UpdateComputerCommandHandler : ICommandHandler<UpdateComputerCommand>
{
    private readonly ILogger<UpdateComputerCommandHandler> _logger;
    private readonly IComputerRepository _computerRepository;
    private readonly IGraphicsCardRepository _graphicsCardRepository;
    private readonly IPowerSupplyRepository _powerSupplyRepository;
    private readonly IProcessorRepository _processorRepository;
    private readonly IRAMRepository _ramRepository;
    private readonly IStorageRepository _storageRepository;
    private readonly IUSBPortsRepository _usbPortsRepository;

    public UpdateComputerCommandHandler(ILogger<UpdateComputerCommandHandler> logger, IComputerRepository computerRepository, IGraphicsCardRepository graphicsCardRepository, IPowerSupplyRepository powerSupplyRepository, IProcessorRepository processorRepository, IRAMRepository ramRepository, IStorageRepository storageRepository, IUSBPortsRepository usbPortsRepository)
    {
        _logger = logger;
        _computerRepository = computerRepository;
        _graphicsCardRepository = graphicsCardRepository;
        _powerSupplyRepository = powerSupplyRepository;
        _processorRepository = processorRepository;
        _ramRepository = ramRepository;
        _storageRepository = storageRepository;
        _usbPortsRepository = usbPortsRepository;
    }

    public async Task<Result> Handle(UpdateComputerCommand request, CancellationToken cancellationToken)
    {
        var computer = await _computerRepository.GetByIdAsync(request.Id);

        if (computer is null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(Computer), nameof(request.Id), request.Id));
        }

        if (request.GraphicsCardId is not null)
        {
            var graphicsCard = await _graphicsCardRepository.GetByIdAsync(request.GraphicsCardId.Value);

            if (graphicsCard is null)
            {
                return Result.Fail(new NotFoundError(_logger, nameof(GraphicsCard), nameof(request.GraphicsCardId), request.GraphicsCardId));
            }
        }

        if (request.PowerSupplyId is not null)
        {
            var powerSupply = await _powerSupplyRepository.GetByIdAsync(request.PowerSupplyId.Value);

            if (powerSupply is null)
            {
                return Result.Fail(new NotFoundError(_logger, nameof(Domain.Entities.PowerSupply), nameof(request.PowerSupplyId), request.PowerSupplyId));
            }
        }
        
        if (request.ProcessorId is not null)
        {
            var processor = await _processorRepository.GetByIdAsync(request.ProcessorId.Value);

            if (processor is null)
            {
                return Result.Fail(new NotFoundError(_logger, nameof(Processor), nameof(request.ProcessorId), request.ProcessorId));
            }
        }

        if (request.RAMId is not null)
        {
            var ram = await _ramRepository.GetByIdAsync(request.RAMId.Value);

            if (ram is null)
            {
                return Result.Fail(new NotFoundError(_logger, nameof(Domain.Entities.RAM), nameof(request.RAMId), request.RAMId));
            }
        }

        if (request.StorageId is not null)
        {
            var storage = await _storageRepository.GetByIdAsync(request.StorageId.Value);

            if (storage is null)
            {
                return Result.Fail(new NotFoundError(_logger, nameof(Domain.Entities.Storage), nameof(request.StorageId), request.StorageId));
            }
        }

        if (!computer.Update(
            request.GraphicsCardId,
            request.PowerSupplyId,
            request.ProcessorId,
            request.RAMId,
            request.StorageId,
            request.WeightInGrams,
            request.USB_2,
            request.USB_3,
            request.USB_C))
        {
            return Result.Fail(new NothingToUpdateError(_logger, nameof(Computer), nameof(request.Id), request.Id));
        }

        await _computerRepository.UpdateAsync(computer);

        return Result.Ok();
    }
}
