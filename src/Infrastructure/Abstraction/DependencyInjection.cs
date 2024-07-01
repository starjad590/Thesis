using Application.Repositories;
using Application.Repositories.Base;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Abstraction;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultDatabase")));

        services.AddScoped<IApplicationDbContext>(sp =>
            sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IComputerRepository, ComputerRepository>();
        services.AddScoped<IGraphicsCardRepository, GraphicsCardRepository>();
        services.AddScoped<IPowerSupplyRepository, PowerSupplyRepository>();
        services.AddScoped<IProcessorRepository, ProcessorRepository>();
        services.AddScoped<IRAMRepository, RAMRepository>();
        services.AddScoped<IStorageRepository, StorageRepository>();
        services.AddScoped<IUSBPortsRepository, USBPortsRepository>();

        return services;
    }
}
