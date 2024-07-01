using Application.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class StorageRepository : GenericRepository<Storage>, IStorageRepository
    {
        public StorageRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Storage?> CheckIfExistsAsync(int amount, string unit, string type)
        {
            return await _context.Storage.Where(x => x.Amount == amount && x.Unit == unit && x.Type == type).FirstOrDefaultAsync();
        }
    }
}
