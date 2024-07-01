using Domain.Entities;

namespace Application.UseCases.Processors.Commands.Add;

public sealed class AddProcessorResponse
{
    public Processor? Processor {  get; set; }
}
