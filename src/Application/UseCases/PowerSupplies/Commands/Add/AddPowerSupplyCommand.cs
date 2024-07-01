using Application.Abstractions.Messaging;

namespace Application.UseCases.PowerSupply.Commands.Add;

public sealed record AddPowerSupplyCommand(
    int Amount
    ) : ICommand<AddPowerSupplyResponse> { }
