
namespace Application.UseCases.PowerSupply.Queries.GetAll;

public sealed class GetAllPowerSuppliesResponse
{
    public List<Domain.Entities.PowerSupply>? PowerSupplies { get; set; }
}
