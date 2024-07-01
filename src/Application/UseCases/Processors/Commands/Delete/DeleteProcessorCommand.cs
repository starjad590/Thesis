using Application.Abstractions.Messaging;

namespace Application.UseCases.Processors.Commands.Delete;

public sealed record DeleteProcessorCommand(Guid Id) : ICommand 
{
}
