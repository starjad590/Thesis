using Domain.Entities;

namespace Application.UseCases.Computers.Queries.GetById;

public sealed class GetComputerByIdResponse
{
    public Computer? Computer { get; set; }
}
