using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Entities;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Processors.Commands.Delete;

internal sealed class DeleteProcessorCommandHandler : ICommandHandler<DeleteProcessorCommand>
{
    private readonly ILogger<DeleteProcessorCommandHandler> _logger;
    private readonly IProcessorRepository _processorRepository;

    public DeleteProcessorCommandHandler(ILogger<DeleteProcessorCommandHandler> logger, IProcessorRepository processorRepository)
    {
        _logger = logger;
        _processorRepository = processorRepository;
    }

    public async Task<Result> Handle(DeleteProcessorCommand request, CancellationToken cancellationToken)
    {
        var processor = await _processorRepository.GetByIdAsync(request.Id);

        if (processor is null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(Processor), nameof(request.Id), request.Id));
        }

        await _processorRepository.DeleteAsync(processor);

        return Result.Ok();
    }
}
