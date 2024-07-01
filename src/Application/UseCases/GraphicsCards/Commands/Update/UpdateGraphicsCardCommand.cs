using Application.Abstractions.Messaging;

namespace Application.UseCases.GraphicsCards.Commands.Update;

public sealed record UpdateGraphicsCardCommand(
    Guid Id,
    string? Make = null,
    string? Model = null,
    string? Version = null
    ) : ICommand { }
