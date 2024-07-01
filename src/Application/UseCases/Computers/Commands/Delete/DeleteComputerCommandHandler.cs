using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Entities;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Computers.Commands.Delete;

internal sealed class DeleteComputerCommandHandler : ICommandHandler<DeleteComputerCommand>
{
    private readonly ILogger<DeleteComputerCommandHandler> _logger;
    private readonly IComputerRepository _computerRepository;

    public DeleteComputerCommandHandler(ILogger<DeleteComputerCommandHandler> logger, IComputerRepository computerRepository)
    {
        _logger = logger;
        _computerRepository = computerRepository;
    }

    public async Task<Result> Handle(DeleteComputerCommand request, CancellationToken cancellationToken)
    {
        var computer = await _computerRepository.GetByIdAsync(request.Id);

        if (computer is null)
        {
            return Result.Fail(new NotFoundError(_logger, nameof(Computer), nameof(request.Id), request.Id));
        }

        await _computerRepository.DeleteAsync(computer);

        return Result.Ok();
    }
}
