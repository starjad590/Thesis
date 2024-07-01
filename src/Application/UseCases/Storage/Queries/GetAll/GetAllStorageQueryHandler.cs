using Application.Abstractions.Messaging;
using Application.Repositories;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Storage.Queries.GetAll;

internal class GetAllStorageQueryHandler : IQueryHandler<GetAllStorageQuery, GetAllStorageResponse>
{
    private readonly ILogger<GetAllStorageQueryHandler> _logger;
    private readonly IStorageRepository _storageRepository;

    public GetAllStorageQueryHandler(ILogger<GetAllStorageQueryHandler> logger, IStorageRepository storageRepository)
    {
        _logger = logger;
        _storageRepository = storageRepository;
    }

    public async Task<Result<GetAllStorageResponse>> Handle(GetAllStorageQuery request, CancellationToken cancellationToken)
    {
        var storage = await _storageRepository.GetAllAsync();

        return Result.Ok(new GetAllStorageResponse
        {
            Storage = storage.ToList()
        });
    }
}
