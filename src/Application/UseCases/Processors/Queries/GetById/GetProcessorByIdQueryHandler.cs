using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Entities;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Processors.Queries.GetById;

internal class GetProcessorByIdQueryHandler : IQueryHandler<GetProcessorByIdQuery, GetProcessorByIdResponse>
{
    private readonly ILogger<GetProcessorByIdQueryHandler> _logger;
    private readonly IProcessorRepository _processorRepository;

    public GetProcessorByIdQueryHandler(ILogger<GetProcessorByIdQueryHandler> logger, IProcessorRepository processorRepository)
    {
        _logger = logger;
        _processorRepository = processorRepository;
    }

    public async Task<Result<GetProcessorByIdResponse>> Handle(GetProcessorByIdQuery request, CancellationToken cancellationToken)
    {
        var processor = await _processorRepository.GetByIdAsync(request.Id);

        if (processor == null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(Processor), nameof(request.Id), request.Id));
        }

        return Result.Ok(new GetProcessorByIdResponse
        {
            Processor = processor
        });
    }
}
