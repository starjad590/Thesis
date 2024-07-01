using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Entities;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Processors.Commands.Add;

internal sealed class AddProcessorCommandHandler : ICommandHandler<AddProcessorCommand, AddProcessorResponse>
{
    private readonly ILogger<AddProcessorCommandHandler> _logger;
    private readonly IProcessorRepository _processorRepository;

    public AddProcessorCommandHandler(ILogger<AddProcessorCommandHandler> logger, IProcessorRepository processorRepository)
    {
        _logger = logger;
        _processorRepository = processorRepository;
    }

    public async Task<Result<AddProcessorResponse>> Handle(AddProcessorCommand request, CancellationToken cancellationToken)
    {
        var processor = await _processorRepository.CheckIfExistsAsync(request.Make, request.Model, request.Version);

        if (processor is not null)
        {
            return Result.Fail(new AlreadyExistsError(_logger, nameof(Processor)));
        }

        var processorEntity = Processor.Create(request.Make, request.Model, request.Version);

        var result = await _processorRepository.AddAsync(processorEntity);

        return Result.Ok(new AddProcessorResponse
        {
            Processor = result
        });
    }
}
