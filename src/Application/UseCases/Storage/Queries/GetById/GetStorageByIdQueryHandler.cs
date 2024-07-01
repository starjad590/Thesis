using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Storage.Queries.GetById;

internal class GetStorageByIdQueryHandler : IQueryHandler<GetStorageByIdQuery, GetStorageByIdResponse>
{
    private readonly ILogger<GetStorageByIdQueryHandler> _logger;
    private readonly IStorageRepository _storageRepository;
    public GetStorageByIdQueryHandler(ILogger<GetStorageByIdQueryHandler> logger, IStorageRepository storageRepository)
    {
        _logger = logger;
        _storageRepository = storageRepository;
    }

    public async Task<Result<GetStorageByIdResponse>> Handle(GetStorageByIdQuery request, CancellationToken cancellationToken)
    {
        var storage = await _storageRepository.GetByIdAsync(request.Id);

        if (storage == null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(Domain.Entities.Storage), nameof(request.Id), request.Id));
        }

        return Result.Ok(new GetStorageByIdResponse
        {
            Storage = storage
        });
    }
}
