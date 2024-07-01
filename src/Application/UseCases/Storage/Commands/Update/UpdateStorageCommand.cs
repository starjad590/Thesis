using Application.Abstractions.Messaging;

namespace Application.UseCases.Storage.Commands.Update;

public sealed record UpdateStorageCommand(
    Guid Id,
    int? Amount = null,
    string? Unit = null,
    string? Type = null
    ) : ICommand { }
