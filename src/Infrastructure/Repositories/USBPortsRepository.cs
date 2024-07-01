using Application.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories
{
    internal class USBPortsRepository : GenericRepository<USBPorts>, IUSBPortsRepository
    {
        public USBPortsRepository(ApplicationDbContext context) : base(context) { }
    }
}
