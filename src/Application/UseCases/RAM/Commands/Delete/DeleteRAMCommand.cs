using Application.Abstractions.Messaging;

namespace Application.UseCases.RAM.Commands.Delete;

public sealed record DeleteRAMCommand(Guid Id) : ICommand 
{
}
