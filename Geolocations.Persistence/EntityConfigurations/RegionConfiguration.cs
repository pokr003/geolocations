using Geolocations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geolocations.Persistence.EntityConfigurations
{
    public sealed class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.Property(r => r.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
            builder.Property(r => r.Name).HasColumnType("varchar").HasMaxLength(255);
            builder.Property(r => r.ZipCode).HasColumnType("varchar").HasMaxLength(50);

            builder.HasMany(r => r.Cities).WithOne(c => c.Region);
            builder.HasIndex(r => r.Name).IsUnique();
        }
    }
}