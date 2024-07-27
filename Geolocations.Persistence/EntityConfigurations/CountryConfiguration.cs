using Geolocations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geolocations.Persistence.EntityConfigurations;

public sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(c => c.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(c => c.ISO2).HasColumnType("varchar").HasMaxLength(3);
        builder.Property(c => c.ISO3).HasColumnType("varchar").HasMaxLength(3);
        builder.Property(c => c.ISONumber).HasColumnType("numeric(3,0)");
        builder.Property(c => c.Name).HasColumnType("varchar").HasMaxLength(255);
        builder.Property(c => c.Capital).HasColumnType("varchar").HasMaxLength(255);
        builder.Property(c => c.WebDomain).HasColumnType("varchar").HasMaxLength(10);
        builder.Property(c => c.PhoneCode).HasColumnType("varchar").HasMaxLength(10);

        builder.HasOne(c => c.Currency);

        builder.HasIndex(
            nameof(Country.Name),
            nameof(Country.ISO2),
            nameof(Country.ISO3),
            nameof(Country.ISONumber)
        ).IsUnique();
    }
}