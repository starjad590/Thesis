using Application.Abstractions.Messaging;

namespace Application.UseCases.PowerSupply.Commands.Update;

public sealed record UpdatePowerSupplyCommand(
    Guid Id,
    int? Amount = null
    ) : ICommand { }
