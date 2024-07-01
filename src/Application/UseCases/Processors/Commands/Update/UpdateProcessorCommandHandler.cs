using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Entities;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Processors.Commands.Update;

internal sealed class UpdateProcessorCommandHandler : ICommandHandler<UpdateProcessorCommand>
{
    private readonly ILogger<UpdateProcessorCommandHandler> _logger;
    private readonly IProcessorRepository _processorRepository;

    public UpdateProcessorCommandHandler(ILogger<UpdateProcessorCommandHandler> logger, IProcessorRepository processorRepository)
    {
        _logger = logger;
        _processorRepository = processorRepository;
    }

    public async Task<Result> Handle(UpdateProcessorCommand request, CancellationToken cancellationToken)
    {
        var processor = await _processorRepository.GetByIdAsync(request.Id);

        if (processor == null) { return Result.Fail(new NotFoundError(_logger, nameof(Processor), nameof(request.Id), request.Id)); }

        if (!processor.Update(request.Make, request.Model, request.Version))
        {
            return Result.Fail(new NothingToUpdateError(_logger, nameof(Processor), nameof(request.Id), request.Id));
        }

        await _processorRepository.UpdateAsync(processor);

        return Result.Ok();
    }
}
