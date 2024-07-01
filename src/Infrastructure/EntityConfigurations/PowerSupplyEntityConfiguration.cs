using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

internal sealed class PowerSupplyEntityCOnfiguration : IEntityTypeConfiguration<PowerSupply>
{
    public void Configure(EntityTypeBuilder<PowerSupply> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Amount).HasMaxLength(4);

        builder.HasIndex(x => x.Id).IsUnique();
    }
}
