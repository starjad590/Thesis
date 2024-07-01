using Application.Repositories.Base;
using Domain.Entities;

namespace Application.Repositories;

public interface IProcessorRepository : IGenericRepository<Processor>
{
    Task<Processor?> CheckIfExistsAsync(string make, string model, string version);
}
