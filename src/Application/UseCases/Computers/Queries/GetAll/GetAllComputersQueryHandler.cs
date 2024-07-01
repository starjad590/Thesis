using Application.Abstractions.Messaging;
using Application.Repositories;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Computers.Queries.GetAll;

internal class GetAllComputersQueryHandler : IQueryHandler<GetAllComputersQuery, GetAllComputersResponse>
{
    private readonly ILogger<GetAllComputersQueryHandler> _logger;
    private readonly IComputerRepository _computersRepository;

    public GetAllComputersQueryHandler(ILogger<GetAllComputersQueryHandler> logger, IComputerRepository computersRepository)
    {
        _logger = logger;
        _computersRepository = computersRepository;
    }

    public async Task<Result<GetAllComputersResponse>> Handle(GetAllComputersQuery request, CancellationToken cancellationToken)
    {
        var computers = await _computersRepository.GetAllComputersAsync();

        return Result.Ok(new GetAllComputersResponse
        {
            Computers = computers
        });
    }
}
