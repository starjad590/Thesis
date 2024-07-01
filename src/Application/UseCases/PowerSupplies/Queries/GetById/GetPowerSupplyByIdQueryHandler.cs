using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.PowerSupply.Queries.GetById;

internal class GetPowerSupplyByIdQueryHandler : IQueryHandler<GetPowerSupplyByIdQuery, GetPowerSupplyByIdResponse>
{
    private readonly ILogger<GetPowerSupplyByIdQueryHandler> _logger;
    private readonly IPowerSupplyRepository _powerSupplyRepository;

    public GetPowerSupplyByIdQueryHandler(ILogger<GetPowerSupplyByIdQueryHandler> logger, IPowerSupplyRepository powerSupplyRepository)
    {
        _logger = logger;
        _powerSupplyRepository = powerSupplyRepository;
    }

    public async Task<Result<GetPowerSupplyByIdResponse>> Handle(GetPowerSupplyByIdQuery request, CancellationToken cancellationToken)
    {
        var powerSupply = await _powerSupplyRepository.GetByIdAsync(request.Id);

        if (powerSupply == null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(Domain.Entities.PowerSupply), nameof(request.Id), request.Id));
        }

        return Result.Ok(new GetPowerSupplyByIdResponse
        {
            PowerSupply = powerSupply
        });
    }
}
