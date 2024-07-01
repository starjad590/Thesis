using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

internal sealed class USBPortsEntityConfiguration : IEntityTypeConfiguration<USBPorts>
{
    public void Configure(EntityTypeBuilder<USBPorts> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.USB_2).HasMaxLength(3);
        builder.Property(p => p.USB_3).HasMaxLength(3);
        builder.Property(p => p.USB_C).HasMaxLength(3);

        builder.HasIndex(x => x.Id).IsUnique();
    }
}
