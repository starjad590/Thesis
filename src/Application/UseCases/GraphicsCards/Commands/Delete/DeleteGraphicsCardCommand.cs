using Application.Abstractions.Messaging;

namespace Application.UseCases.GraphicsCards.Commands.Delete;

public sealed record DeleteGraphicsCardCommand(Guid Id) : ICommand 
{
}
