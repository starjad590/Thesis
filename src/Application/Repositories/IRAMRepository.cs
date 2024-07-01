using Application.Repositories.Base;
using Domain.Entities;

namespace Application.Repositories;

public interface IRAMRepository : IGenericRepository<RAM>
{
    Task<RAM?> CheckIfExistsAsync(int amount, string unit);
}
