using Application.Abstractions.Messaging;
using Application.Repositories;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.GraphicsCards.Queries.GetAll;

internal class GetAllGraphicsCardsQueryHandler : IQueryHandler<GetAllGraphicsCardsQuery, GetAllGraphicsCardsResponse>
{
    private readonly ILogger<GetAllGraphicsCardsQueryHandler> _logger;
    private readonly IGraphicsCardRepository _graphicsCardRepository;

    public GetAllGraphicsCardsQueryHandler(ILogger<GetAllGraphicsCardsQueryHandler> logger, IGraphicsCardRepository graphicsCardRepository)
    {
        _logger = logger;
        _graphicsCardRepository = graphicsCardRepository;
    }

    public async Task<Result<GetAllGraphicsCardsResponse>> Handle(GetAllGraphicsCardsQuery request, CancellationToken cancellationToken)
    {
        var graphicsCards = await _graphicsCardRepository.GetAllAsync();

        return Result.Ok(new GetAllGraphicsCardsResponse
        {
            GraphicsCards = graphicsCards.ToList()
        });
    }
}
