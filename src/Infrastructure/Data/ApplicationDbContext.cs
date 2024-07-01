using Application.Repositories.Base;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
            
    }

    public DbSet<Computer> Computers { get; set; }
    public DbSet<GraphicsCard> GraphicsCards { get; set; }
    public DbSet<PowerSupply> PowerSupplies { get; set; }
    public DbSet<Processor> Processors { get; set; }
    public DbSet<RAM> RAM { get; set; }
    public DbSet<Storage> Storage { get; set; }
    public DbSet<USBPorts> USBPorts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
