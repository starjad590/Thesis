using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.RAM.Queries.GetById;

internal class GetRAMByIdQueryHandler : IQueryHandler<GetRAMByIdQuery, GetRAMByIdResponse>
{
    private readonly ILogger<GetRAMByIdQueryHandler> _logger;
    private readonly IRAMRepository _ramRepository;

    public GetRAMByIdQueryHandler(ILogger<GetRAMByIdQueryHandler> logger, IRAMRepository ramRepository)
    {
        _logger = logger;
        _ramRepository = ramRepository;
    }

    public async Task<Result<GetRAMByIdResponse>> Handle(GetRAMByIdQuery request, CancellationToken cancellationToken)
    {
        var ram = await _ramRepository.GetByIdAsync(request.Id);

        if (ram == null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(Domain.Entities.Storage), nameof(request.Id), request.Id));
        }

        return Result.Ok(new GetRAMByIdResponse
        {
            RAM = ram
        });
    }
}
