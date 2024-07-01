using Domain.Entities;

namespace Application.UseCases.Processors.Queries.GetById;

public sealed class GetProcessorByIdResponse
{
    public Processor? Processor { get; set; }
}
