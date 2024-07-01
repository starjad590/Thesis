using Application.Repositories.Base;
using Domain.Entities;

namespace Application.Repositories;

public interface IPowerSupplyRepository : IGenericRepository<PowerSupply>
{
    Task<PowerSupply?> CheckIfExistsAsync(int amount);
}
