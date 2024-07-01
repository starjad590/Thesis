using Application.Abstractions.Messaging;

namespace Application.UseCases.RAM.Commands.Add;

public sealed record AddRAMCommand(
    int Amount,
    string Unit
    ) : ICommand<AddRAMResponse> { }
