using Application.Abstractions.Messaging;
using Application.Repositories;
using Domain.Errors;
using FluentResults;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.RAM.Commands.Add;

internal sealed class AddRAMCommandHandler : ICommandHandler<AddRAMCommand, AddRAMResponse>
{
    private readonly ILogger<AddRAMCommandHandler> _logger;
    private readonly IRAMRepository _ramRepository;

    public AddRAMCommandHandler(ILogger<AddRAMCommandHandler> logger, IRAMRepository ramRepository)
    {
        _logger = logger;
        _ramRepository = ramRepository;
    }

    public async Task<Result<AddRAMResponse>> Handle(AddRAMCommand request, CancellationToken cancellationToken)
    {
        var ram = await _ramRepository.CheckIfExistsAsync(request.Amount, request.Unit);

        if (ram is not null)
        {
            return Result.Fail(new AlreadyExistsError(_logger, nameof(RAM)));
        }

        var ramEntity = Domain.Entities.RAM.Create(request.Amount, request.Unit);

        var result = await _ramRepository.AddAsync(ramEntity);

        return Result.Ok(new AddRAMResponse
        {
            RAM = result
        });
    }
}
