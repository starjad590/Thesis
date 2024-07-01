using Application.Abstractions.Messaging;
using Application.Repositories;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Processors.Queries.GetAll;

internal class GetAllProcessorsQueryHandler : IQueryHandler<GetAllProcessorsQuery, GetAllProcessorsResponse>
{
    private readonly ILogger<GetAllProcessorsQueryHandler> _logger;
    private readonly IProcessorRepository _processorRepository;

    public GetAllProcessorsQueryHandler(ILogger<GetAllProcessorsQueryHandler> logger, IProcessorRepository processorRepository)
    {
        _logger = logger;
        _processorRepository = processorRepository;
    }

    public async Task<Result<GetAllProcessorsResponse>> Handle(GetAllProcessorsQuery request, CancellationToken cancellationToken)
    {
        var processors = await _processorRepository.GetAllAsync();

        return Result.Ok(new GetAllProcessorsResponse
        {
            Processors = processors.ToList()
        });
    }
}
