
namespace Application.UseCases.Computers.Queries.GetAll;

public sealed class GetAllComputersResponse
{
    public List<Domain.Entities.Computer>? Computers { get; set; }
}
