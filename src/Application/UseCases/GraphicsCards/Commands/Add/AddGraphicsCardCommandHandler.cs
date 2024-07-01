using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Entities;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.GraphicsCards.Commands.Add;

internal sealed class AddGraphicsCardCommandHandler : ICommandHandler<AddGraphicsCardCommand, AddGraphicsCardResponse>
{
    private readonly ILogger<AddGraphicsCardCommandHandler> _logger;
    private readonly IGraphicsCardRepository _graphicsCardRepository;

    public AddGraphicsCardCommandHandler(ILogger<AddGraphicsCardCommandHandler> logger, IGraphicsCardRepository graphicsCardRepository)
    {
        _logger = logger;
        _graphicsCardRepository = graphicsCardRepository;
    }

    public async Task<Result<AddGraphicsCardResponse>> Handle(AddGraphicsCardCommand request, CancellationToken cancellationToken)
    {
        var graphicsCard = await _graphicsCardRepository.CheckIfExistsAsync(request.Make, request.Model, request.Version);

        if (graphicsCard is not null)
        {
            return Result.Fail(new AlreadyExistsError(_logger, nameof(GraphicsCard)));
        }

        var graphicsCardEntity = GraphicsCard.Create(request.Make, request.Model, request.Version);

        var result = await _graphicsCardRepository.AddAsync(graphicsCardEntity);

        return Result.Ok(new AddGraphicsCardResponse
        {
            GraphicsCard = result
        });
    }
}
