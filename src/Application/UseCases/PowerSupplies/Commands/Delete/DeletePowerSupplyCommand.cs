using Application.Abstractions.Messaging;

namespace Application.UseCases.PowerSupply.Commands.Delete;

public sealed record DeletePowerSupplyCommand(Guid Id) : ICommand 
{
}
