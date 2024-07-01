using Application.Abstractions.Messaging;

namespace Application.UseCases.Processors.Commands.Add;

public sealed record AddProcessorCommand(
    string Make,
    string Model,
    string Version
    ) : ICommand<AddProcessorResponse> { }
