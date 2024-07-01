using Application.Abstractions.Messaging;

namespace Application.UseCases.Computers.Commands.Delete;

public sealed record DeleteComputerCommand(Guid Id) : ICommand 
{
}
