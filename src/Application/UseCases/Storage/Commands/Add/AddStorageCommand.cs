using Application.Abstractions.Messaging;

namespace Application.UseCases.Storage.Commands.Add;

public sealed record AddStorageCommand(
    int Amount,
    string Unit,
    string Type
    ) : ICommand<AddStorageResponse> { }
