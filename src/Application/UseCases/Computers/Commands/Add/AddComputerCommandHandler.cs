using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Entities;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Computers.Commands.Add;

internal sealed class AddComputerCommandHandler : ICommandHandler<AddComputerCommand, AddComputerResponse>
{
    private readonly ILogger<AddComputerCommandHandler> _logger;
    private readonly IComputerRepository _computerRepository;
    private readonly IGraphicsCardRepository _graphicsCardRepository;
    private readonly IPowerSupplyRepository _powerSupplyRepository;
    private readonly IProcessorRepository _processorRepository;
    private readonly IRAMRepository _ramRepository;
    private readonly IStorageRepository _storageRepository;
    private readonly IUSBPortsRepository _usbPortsRepository;

    public AddComputerCommandHandler(ILogger<AddComputerCommandHandler> logger, IComputerRepository computerRepository, IGraphicsCardRepository graphicsCardRepository, IPowerSupplyRepository powerSupplyRepository, IProcessorRepository processorRepository, IRAMRepository ramRepository, IStorageRepository storageRepository, IUSBPortsRepository usbPortsRepository)
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

    public async Task<Result<AddComputerResponse>> Handle(AddComputerCommand request, CancellationToken cancellationToken)
    {
        var computer = await _computerRepository.CheckIfExistsAsync(
            request.GraphicsCardId,
            request.PowerSupplyId,
            request.ProcessorId,
            request.RAMId,
            request.StorageId,
            request.WeightInGrams,
            request.USB_2,
            request.USB_3,
            request.USB_C
            );

        if ( computer is not null ) 
        {
            return Result.Fail(new AlreadyExistsError(_logger, nameof(Computer)));
        }

        var graphicsCard = await _graphicsCardRepository.GetByIdAsync(request.GraphicsCardId);

        if (graphicsCard is null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(GraphicsCard), nameof(request.GraphicsCardId), request.GraphicsCardId));
        }

        var powerSupply = await _powerSupplyRepository.GetByIdAsync(request.PowerSupplyId);

        if (powerSupply is null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(Domain.Entities.PowerSupply), nameof(request.PowerSupplyId), request.PowerSupplyId));
        }

        var processor = await _processorRepository.GetByIdAsync(request.ProcessorId);

        if (processor is null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(Processor), nameof(request.ProcessorId), request.ProcessorId));
        }

        var ram = await _ramRepository.GetByIdAsync(request.RAMId);

        if (ram is null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(Domain.Entities.RAM), nameof(request.RAMId), request.RAMId));
        }

        var storage = await _storageRepository.GetByIdAsync(request.StorageId);

        if (storage is null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(Domain.Entities.Storage), nameof(request.StorageId), request.StorageId));
        }

        var computerEntity = Computer.Create(
            request.GraphicsCardId,
            request.PowerSupplyId,
            request.ProcessorId,
            request.RAMId,
            request.StorageId,
            request.WeightInGrams,
            request.USB_2,
            request.USB_3,
            request.USB_C);

        var result = await _computerRepository.AddAsync(computerEntity);

        return Result.Ok(new AddComputerResponse { Computer = result });
    }
}
