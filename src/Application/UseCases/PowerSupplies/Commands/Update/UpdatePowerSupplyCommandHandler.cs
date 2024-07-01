using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.PowerSupply.Commands.Update;

internal sealed class UpdatePowerSupplyCommandHandler : ICommandHandler<UpdatePowerSupplyCommand>
{
    private readonly ILogger<UpdatePowerSupplyCommandHandler> _logger;
    private readonly IPowerSupplyRepository _powerSupplyRepository;

    public UpdatePowerSupplyCommandHandler(ILogger<UpdatePowerSupplyCommandHandler> logger, IPowerSupplyRepository powerSupplyRepository)
    {
        _logger = logger;
        _powerSupplyRepository = powerSupplyRepository;
    }

    public async Task<Result> Handle(UpdatePowerSupplyCommand request, CancellationToken cancellationToken)
    {
        var powerSupply = await _powerSupplyRepository.GetByIdAsync(request.Id);

        if (powerSupply == null) { return Result.Fail(new NotFoundError(_logger, nameof(Domain.Entities.PowerSupply), nameof(request.Id), request.Id)); }

        if (!powerSupply.Update(request.Amount))
        {
            return Result.Fail(new NothingToUpdateError(_logger, nameof(Domain.Entities.PowerSupply), nameof(request.Id), request.Id));
        }

        await _powerSupplyRepository.UpdateAsync(powerSupply);

        return Result.Ok();
    }
}
