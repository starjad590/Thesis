using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Storage.Commands.Update;

internal sealed class UpdateStorageCommandHandler : ICommandHandler<UpdateStorageCommand>
{
    private readonly ILogger<UpdateStorageCommandHandler> _logger;
    private readonly IStorageRepository _storageRepository;

    public UpdateStorageCommandHandler(ILogger<UpdateStorageCommandHandler> logger, IStorageRepository storageRepository)
    {
        _logger = logger;
        _storageRepository = storageRepository;
    }

    public async Task<Result> Handle(UpdateStorageCommand request, CancellationToken cancellationToken)
    {
        var storage = await _storageRepository.GetByIdAsync(request.Id);

        if (storage == null) { return Result.Fail(new NotFoundError(_logger, nameof(Domain.Entities.Storage), nameof(request.Id), request.Id)); }

        if (!storage.Update(request.Amount, request.Unit, request.Type))
        {
            return Result.Fail(new NothingToUpdateError(_logger, nameof(Domain.Entities.Storage), nameof(request.Id), request.Id));
        }

        await _storageRepository.UpdateAsync(storage);

        return Result.Ok();
    }
}
