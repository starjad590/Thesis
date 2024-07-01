using Application.Repositories.Base;
using Domain.Entities;

namespace Application.Repositories;

public interface IGraphicsCardRepository : IGenericRepository<GraphicsCard>
{
    Task<GraphicsCard?> CheckIfExistsAsync(string make, string model, string version);
}
