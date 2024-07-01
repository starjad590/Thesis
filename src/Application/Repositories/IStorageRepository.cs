using Application.Repositories.Base;
using Domain.Entities;

namespace Application.Repositories;

public interface IStorageRepository : IGenericRepository<Storage>
{
    Task<Storage?> CheckIfExistsAsync(int amount, string unit, string type);
}
