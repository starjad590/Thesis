using Domain.Entities;

namespace Application.UseCases.Processors.Queries.GetAll;

public sealed class GetAllProcessorsResponse
{
    public List<Processor>? Processors { get; set; }
}
