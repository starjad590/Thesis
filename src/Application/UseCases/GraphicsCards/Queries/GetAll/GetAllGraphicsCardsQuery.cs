using Application.Abstractions.Messaging;

namespace Application.UseCases.GraphicsCards.Queries.GetAll;

public sealed record GetAllGraphicsCardsQuery() : IQuery<GetAllGraphicsCardsResponse> { }
