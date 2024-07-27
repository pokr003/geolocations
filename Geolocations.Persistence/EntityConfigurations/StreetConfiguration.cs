using Geolocations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geolocations.Persistence.EntityConfigurations;

public sealed class StreetConfiguration : IEntityTypeConfiguration<Street>
{
    public void Configure(EntityTypeBuilder<Street> builder)
    {
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(c => c.Name).HasColumnType("varchar").HasMaxLength(255);
        builder.HasOne(s => s.City).WithMany(c => c.Streets);
    }
}
