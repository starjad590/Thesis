using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

internal sealed class StorageEntityCOnfiguration : IEntityTypeConfiguration<Storage>
{
    public void Configure(EntityTypeBuilder<Storage> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Amount).HasMaxLength(4);
        builder.Property(p => p.Unit).HasMaxLength(2);
        builder.Property(p => p.Type).HasMaxLength(3);

        builder.HasIndex(x => x.Id).IsUnique();
    }
}
