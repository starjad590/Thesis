using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Storage.Commands.Delete;

internal sealed class DeleteStorageCommandHandler : ICommandHandler<DeleteStorageCommand>
{
    private readonly ILogger<DeleteStorageCommandHandler> _logger;
    private readonly IStorageRepository _storageRepository;

    public DeleteStorageCommandHandler(ILogger<DeleteStorageCommandHandler> logger, IStorageRepository storageRepository)
    {
        _logger = logger;
        _storageRepository = storageRepository;
    }

    public async Task<Result> Handle(DeleteStorageCommand request, CancellationToken cancellationToken)
    {
        var storage = await _storageRepository.GetByIdAsync(request.Id);

        if (storage is null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(Domain.Entities.RAM), nameof(request.Id), request.Id));
        }

        await _storageRepository.DeleteAsync(storage);

        return Result.Ok();
    }
}
