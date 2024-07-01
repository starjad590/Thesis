using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Entities;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.GraphicsCards.Commands.Delete;

internal sealed class DeleteGraphicsCardCommandHandler : ICommandHandler<DeleteGraphicsCardCommand>
{
    private readonly ILogger<DeleteGraphicsCardCommandHandler> _logger;
    private readonly IGraphicsCardRepository _graphicsCardRepository;

    public DeleteGraphicsCardCommandHandler(ILogger<DeleteGraphicsCardCommandHandler> logger, IGraphicsCardRepository graphicsCardRepository)
    {
        _logger = logger;
        _graphicsCardRepository = graphicsCardRepository;
    }

    public async Task<Result> Handle(DeleteGraphicsCardCommand request, CancellationToken cancellationToken)
    {
        var graphicsCard = await _graphicsCardRepository.GetByIdAsync(request.Id);

        if (graphicsCard is null) 
        { 
            return Result.Fail(new NotFoundError(_logger, nameof(GraphicsCard), nameof(request.Id), request.Id));
        }

        await _graphicsCardRepository.DeleteAsync(graphicsCard);

        return Result.Ok();
    }
}
