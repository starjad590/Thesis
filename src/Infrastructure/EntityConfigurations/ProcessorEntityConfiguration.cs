using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

internal sealed class ProcessorEntityCOnfiguration : IEntityTypeConfiguration<Processor>
{
    public void Configure(EntityTypeBuilder<Processor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Make).HasMaxLength(100);
        builder.Property(p => p.Model).HasMaxLength(200);
        builder.Property(p => p.Version).HasMaxLength(200);

        builder.HasIndex(x => x.Id).IsUnique();
    }
}
