using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Storage.Commands.Add;

internal sealed class AddStorageCommandHandler : ICommandHandler<AddStorageCommand, AddStorageResponse>
{
    private readonly ILogger<AddStorageCommandHandler> _logger;
    private readonly IStorageRepository _storageRepository;

    public AddStorageCommandHandler(ILogger<AddStorageCommandHandler> logger, IStorageRepository storageRepository)
    {
        _logger = logger;
        _storageRepository = storageRepository;
    }

    public async Task<Result<AddStorageResponse>> Handle(AddStorageCommand request, CancellationToken cancellationToken)
    {
        var storage = await _storageRepository.CheckIfExistsAsync(request.Amount, request.Unit, request.Type);

        if (storage is not null) 
        {
            return Result.Fail(new AlreadyExistsError(_logger, nameof(Storage)));
        }

        var storageEntity = Domain.Entities.Storage.Create(request.Amount, request.Unit, request.Type);

        var result = await _storageRepository.AddAsync(storageEntity);

        return Result.Ok(new AddStorageResponse
        {
            Storage = result
        });
    }
}
