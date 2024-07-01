using Application.Abstractions.Messaging;

namespace Application.UseCases.RAM.Commands.Update;

public sealed record UpdateRAMCommand(
    Guid Id,
    int? Amount = null,
    string? Unit = null
    ) : ICommand { }
