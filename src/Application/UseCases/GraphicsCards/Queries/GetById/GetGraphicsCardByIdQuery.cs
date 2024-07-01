using Application.Abstractions.Messaging;

namespace Application.UseCases.GraphicsCards.Queries.GetById;

public sealed record GetGraphicsCardByIdQuery(Guid Id) : IQuery<GetGraphicsCardByIdResponse> { }
