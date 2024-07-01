using Application.Repositories;
using Azure.Core;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class ProcessorRepository : GenericRepository<Processor>, IProcessorRepository
    {
        public ProcessorRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Processor?> CheckIfExistsAsync(string make, string model, string version)
        {
            return await _context.Processors.Where(x => x.Make == make && x.Model == model && x.Version == version).FirstOrDefaultAsync();
        }
    }
}
