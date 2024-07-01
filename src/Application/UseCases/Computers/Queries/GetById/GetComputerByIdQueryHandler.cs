using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Entities;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Computers.Queries.GetById;

internal class GetComputerByIdQueryHandler : IQueryHandler<GetComputerByIdQuery, GetComputerByIdResponse>
{
    private readonly ILogger<GetComputerByIdQueryHandler> _logger;
    private readonly IComputerRepository _computerRepository;

    public GetComputerByIdQueryHandler(ILogger<GetComputerByIdQueryHandler> logger, IComputerRepository computerRepository)
    {
        _logger = logger;
        _computerRepository = computerRepository;
    }

    public async Task<Result<GetComputerByIdResponse>> Handle(GetComputerByIdQuery request, CancellationToken cancellationToken)
    {
        var computer = await _computerRepository.GetByComputerIdAsync(request.Id);

        if (computer == null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(Computer), nameof(request.Id), request.Id));
        }

        return Result.Ok(new GetComputerByIdResponse
        {
            Computer = computer
        });
    }
}
