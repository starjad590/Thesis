using Application.Abstractions.Messaging;

namespace Application.UseCases.Storage.Commands.Delete;

public sealed record DeleteStorageCommand(Guid Id) : ICommand 
{
}
