using Geolocations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geolocations.Persistence.EntityConfigurations;

public sealed class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(c => c.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(c => c.Name).HasColumnType("varchar").HasMaxLength(255);
        builder.Property(c => c.ZipCode).HasColumnType("varchar").HasMaxLength(50);

        builder.HasOne(c => c.Region).WithMany(r => r.Cities);
        builder.HasIndex(r => r.Name).IsUnique();
    }
}
