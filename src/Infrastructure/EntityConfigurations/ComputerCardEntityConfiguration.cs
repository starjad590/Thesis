using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

internal sealed class ComputerEntityConfiguration : IEntityTypeConfiguration<Computer>
{
    public void Configure(EntityTypeBuilder<Computer> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(c => c.GraphicsCard)
            .WithMany()
            .HasForeignKey(c => c.GraphicsCardId);

        builder
            .HasOne(c => c.PowerSupply)
            .WithMany()
            .HasForeignKey(c => c.PowerSupplyId);

        builder
            .HasOne(c => c.Processor)
            .WithMany()
            .HasForeignKey(c => c.ProcessorId);

        builder
            .HasOne(c => c.RAM)
            .WithMany()
            .HasForeignKey(c => c.RAMId);

        builder
            .HasOne(c => c.Storage)
            .WithMany()
            .HasForeignKey(c => c.StorageId);

        builder
            .HasOne(c => c.USBPorts)
            .WithMany()
            .HasForeignKey(c => c.USBPortsId);

        builder.Property(p => p.WeightInGrams);

        builder.HasIndex(x => x.Id).IsUnique();
    }
}
