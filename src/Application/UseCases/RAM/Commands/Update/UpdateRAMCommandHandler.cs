using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Entities;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.RAM.Commands.Update;

internal sealed class UpdateRAMCommandHandler : ICommandHandler<UpdateRAMCommand>
{
    private readonly ILogger<UpdateRAMCommandHandler> _logger;
    private readonly IRAMRepository _ramRepository;

    public UpdateRAMCommandHandler(ILogger<UpdateRAMCommandHandler> logger, IRAMRepository ramRepository)
    {
        _logger = logger;
        _ramRepository = ramRepository;
    }

    public async Task<Result> Handle(UpdateRAMCommand request, CancellationToken cancellationToken)
    {
        var processor = await _ramRepository.GetByIdAsync(request.Id);

        if (processor == null) { return Result.Fail(new NotFoundError(_logger, nameof(Domain.Entities.RAM), nameof(request.Id), request.Id)); }

        if (!processor.Update(request.Amount, request.Unit))
        {
            return Result.Fail(new NothingToUpdateError(_logger, nameof(Domain.Entities.RAM), nameof(request.Id), request.Id));
        }

        await _ramRepository.UpdateAsync(processor);

        return Result.Ok();
    }
}
