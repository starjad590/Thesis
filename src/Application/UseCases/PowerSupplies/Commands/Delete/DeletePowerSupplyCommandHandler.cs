using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.PowerSupply.Commands.Delete;

internal sealed class DeletePowerSupplyCommandHandler : ICommandHandler<DeletePowerSupplyCommand>
{
    private readonly ILogger<DeletePowerSupplyCommandHandler> _logger;
    private readonly IPowerSupplyRepository _powerSupplyRepository;

    public DeletePowerSupplyCommandHandler(ILogger<DeletePowerSupplyCommandHandler> logger, IPowerSupplyRepository powerSupplyRepository)
    {
        _logger = logger;
        _powerSupplyRepository = powerSupplyRepository;
    }

    public async Task<Result> Handle(DeletePowerSupplyCommand request, CancellationToken cancellationToken)
    {
        var powerSupply = await _powerSupplyRepository.GetByIdAsync(request.Id);

        if (powerSupply is null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(Domain.Entities.PowerSupply), nameof(request.Id), request.Id));
        }

        await _powerSupplyRepository.DeleteAsync(powerSupply);

        return Result.Ok();
    }
}
