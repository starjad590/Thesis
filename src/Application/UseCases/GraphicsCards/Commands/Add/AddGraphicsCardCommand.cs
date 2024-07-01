using Application.Abstractions.Messaging;

namespace Application.UseCases.GraphicsCards.Commands.Add;

public sealed record AddGraphicsCardCommand(
    string Make,
    string Model,
    string Version
    ) : ICommand<AddGraphicsCardResponse> { }
