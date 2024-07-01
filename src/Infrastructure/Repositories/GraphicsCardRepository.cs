using Application.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class GraphicsCardRepository : GenericRepository<GraphicsCard>, IGraphicsCardRepository
    {
        public GraphicsCardRepository(ApplicationDbContext context) : base(context) { }

        public async Task<GraphicsCard?> CheckIfExistsAsync(string make, string model, string version)
        {
            return await _context.GraphicsCards.Where(x => x.Make == make && x.Model == model && x.Version == version).FirstOrDefaultAsync();
        }
    }
}
