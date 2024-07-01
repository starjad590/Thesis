using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Entities;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.RAM.Commands.Delete;

internal sealed class DeleteRAMCommandHandler : ICommandHandler<DeleteRAMCommand>
{
    private readonly ILogger<DeleteRAMCommandHandler> _logger;
    private readonly IRAMRepository _ramRepository;

    public DeleteRAMCommandHandler(ILogger<DeleteRAMCommandHandler> logger, IRAMRepository ramRepository)
    {
        _logger = logger;
        _ramRepository = ramRepository;
    }

    public async Task<Result> Handle(DeleteRAMCommand request, CancellationToken cancellationToken)
    {
        var ram = await _ramRepository.GetByIdAsync(request.Id);

        if (ram is null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(Domain.Entities.RAM), nameof(request.Id), request.Id));
        }

        await _ramRepository.DeleteAsync(ram);

        return Result.Ok();
    }
}
