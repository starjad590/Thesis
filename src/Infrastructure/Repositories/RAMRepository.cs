using Application.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class RAMRepository : GenericRepository<RAM>, IRAMRepository
    {
        public RAMRepository(ApplicationDbContext context) : base(context) { }

        public async Task<RAM?> CheckIfExistsAsync(int amount, string unit)
        {
            return await _context.RAM.Where(x => x.Amount == amount && x.Unit == unit).FirstOrDefaultAsync();
        }
    }
}
