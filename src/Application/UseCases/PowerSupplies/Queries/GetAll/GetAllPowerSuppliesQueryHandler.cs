using Application.Abstractions.Messaging;
using Application.Repositories;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.PowerSupply.Queries.GetAll;

internal class GetAllPowerSuppliesQueryHandler : IQueryHandler<GetAllPowerSuppliesQuery, GetAllPowerSuppliesResponse>
{
    private readonly ILogger<GetAllPowerSuppliesQueryHandler> _logger;
    private readonly IPowerSupplyRepository _powerSupplyRepository;

    public GetAllPowerSuppliesQueryHandler(ILogger<GetAllPowerSuppliesQueryHandler> logger, IPowerSupplyRepository powerSupplyRepository)
    {
        _logger = logger;
        _powerSupplyRepository = powerSupplyRepository;
    }

    public async Task<Result<GetAllPowerSuppliesResponse>> Handle(GetAllPowerSuppliesQuery request, CancellationToken cancellationToken)
    {
        var powerSupplies = await _powerSupplyRepository.GetAllAsync();

        return Result.Ok(new GetAllPowerSuppliesResponse
        {
            PowerSupplies = powerSupplies.ToList()
        });
    }
}
