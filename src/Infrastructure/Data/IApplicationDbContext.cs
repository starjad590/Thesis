using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public interface IApplicationDbContext
{
    DbSet<Computer> Computers { get; set; }
    DbSet<GraphicsCard> GraphicsCards { get; set; }
    DbSet<PowerSupply> PowerSupplies { get; set; }
    DbSet<Processor> Processors { get; set; }
    DbSet<RAM> RAM { get; set; }
    DbSet<Storage> Storage { get; set; }
    DbSet<USBPorts> USBPorts { get; set; }
}
