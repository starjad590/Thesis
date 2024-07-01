using Application.Abstractions.Messaging;
using Application.Repositories;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.RAM.Queries.GetAll;

internal class GetAllRAMQueryHandler : IQueryHandler<GetAllRAMQuery, GetAllRAMResponse>
{
    private readonly ILogger<GetAllRAMQueryHandler> _logger;
    private readonly IRAMRepository _ramRepository;

    public GetAllRAMQueryHandler(ILogger<GetAllRAMQueryHandler> logger, IRAMRepository ramRepository)
    {
        _logger = logger;
        _ramRepository = ramRepository;
    }

    public async Task<Result<GetAllRAMResponse>> Handle(GetAllRAMQuery request, CancellationToken cancellationToken)
    {
        var ram = await _ramRepository.GetAllAsync();

        return Result.Ok(new GetAllRAMResponse
        {
            RAM = ram.ToList()
        });
    }
}
