using Application.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class PowerSupplyRepository : GenericRepository<PowerSupply>, IPowerSupplyRepository
    {
        public PowerSupplyRepository(ApplicationDbContext context) : base(context) { }

        public async Task<PowerSupply?> CheckIfExistsAsync(int amount)
        {
            return await _context.PowerSupplies.Where(x => x.Amount == amount).FirstOrDefaultAsync();
        }
    }
}
