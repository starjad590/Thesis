using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Entities;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.GraphicsCards.Commands.Update;

internal sealed class UpdateGraphicsCardCommandHandler : ICommandHandler<UpdateGraphicsCardCommand>
{
    private readonly ILogger<UpdateGraphicsCardCommandHandler> _logger;
    private readonly IGraphicsCardRepository _graphicsCardRepository;

    public UpdateGraphicsCardCommandHandler(ILogger<UpdateGraphicsCardCommandHandler> logger, IGraphicsCardRepository graphicsCardRepository)
    {
        _logger = logger;
        _graphicsCardRepository = graphicsCardRepository;
    }

    public async Task<Result> Handle(UpdateGraphicsCardCommand request, CancellationToken cancellationToken)
    {
        var graphicsCard = await _graphicsCardRepository.GetByIdAsync(request.Id);

        if (graphicsCard == null) { return Result.Fail(new NotFoundError(_logger, nameof(GraphicsCard), nameof(request.Id), request.Id)); }

        if (!graphicsCard.Update(request.Make, request.Model, request.Version)) 
        { 
            return Result.Fail(new NothingToUpdateError(_logger, nameof(GraphicsCard), nameof(request.Id), request.Id)); 
        }

        await _graphicsCardRepository.UpdateAsync(graphicsCard);

        return Result.Ok();
    }
}
