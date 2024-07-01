using Domain.Entities;

namespace Application.UseCases.GraphicsCards.Queries.GetById;

public sealed class GetGraphicsCardByIdResponse
{
    public GraphicsCard? GraphicsCard { get; set; }
}
