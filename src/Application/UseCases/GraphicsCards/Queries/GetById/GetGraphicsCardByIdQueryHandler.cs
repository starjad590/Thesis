using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Entities;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.GraphicsCards.Queries.GetById;

internal class GetGraphicsCardByIdQueryHandler : IQueryHandler<GetGraphicsCardByIdQuery, GetGraphicsCardByIdResponse>
{
    private readonly ILogger<GetGraphicsCardByIdQueryHandler> _logger;
    private readonly IGraphicsCardRepository _graphicsCardRepository;

    public GetGraphicsCardByIdQueryHandler(ILogger<GetGraphicsCardByIdQueryHandler> logger, IGraphicsCardRepository graphicsCardRepository)
    {
        _logger = logger;
        _graphicsCardRepository = graphicsCardRepository;
    }

    public async Task<Result<GetGraphicsCardByIdResponse>> Handle(GetGraphicsCardByIdQuery request, CancellationToken cancellationToken)
    {
        var grapchicsCard = await _graphicsCardRepository.GetByIdAsync(request.Id);

        if (grapchicsCard == null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(GraphicsCard), nameof(request.Id), request.Id));
        }

        return Result.Ok(new GetGraphicsCardByIdResponse 
        { 
            GraphicsCard = grapchicsCard
        });
    }
}
