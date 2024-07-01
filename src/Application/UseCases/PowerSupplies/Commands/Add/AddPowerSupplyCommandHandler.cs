using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.PowerSupply.Commands.Add;

internal sealed class AddPowerSupplyCommandHandler : ICommandHandler<AddPowerSupplyCommand, AddPowerSupplyResponse>
{
    private readonly ILogger<AddPowerSupplyCommandHandler> _logger;
    private readonly IPowerSupplyRepository _powerSupplyRepository;

    public AddPowerSupplyCommandHandler(ILogger<AddPowerSupplyCommandHandler> logger, IPowerSupplyRepository powerSupplyRepository)
    {
        _logger = logger;
        _powerSupplyRepository = powerSupplyRepository;
    }

    public async Task<Result<AddPowerSupplyResponse>> Handle(AddPowerSupplyCommand request, CancellationToken cancellationToken)
    {
        var powerSupply = await _powerSupplyRepository.CheckIfExistsAsync(request.Amount);

        if (powerSupply is not null)
        {
            return Result.Fail(new AlreadyExistsError(_logger, nameof(PowerSupply)));
        }

        var powerSupplyEntity = Domain.Entities.PowerSupply.Create(request.Amount);

        var result = await _powerSupplyRepository.AddAsync(powerSupplyEntity);

        return Result.Ok(new AddPowerSupplyResponse
        {
            PowerSupply = result
        });
    }
}
