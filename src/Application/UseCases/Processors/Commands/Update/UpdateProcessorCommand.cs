using Application.Abstractions.Messaging;

namespace Application.UseCases.Processors.Commands.Update;

public sealed record UpdateProcessorCommand(
    Guid Id,
    string? Make = null,
    string? Model = null,
    string? Version = null
    ) : ICommand { }
