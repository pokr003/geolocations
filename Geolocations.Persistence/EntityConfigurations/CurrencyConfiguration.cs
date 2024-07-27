using Geolocations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geolocations.Persistence.EntityConfigurations;

public sealed class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.Property(c => c.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(c => c.ISOCode).HasColumnType("varchar").HasMaxLength(3);
        builder.Property(c => c.ISONumber).HasColumnType("numeric(3,0)");
        builder.Property(c => c.ShortName).HasColumnType("varchar").HasMaxLength(20);
        builder.Property(c => c.FullName).HasColumnType("varchar").HasMaxLength(255);
        builder.Property(c => c.Symbol).HasColumnType("varchar").HasMaxLength(5);
        builder.HasIndex(c => c.ISOCode).IsUnique();
        builder.HasIndex(c => c.ISONumber).IsUnique();
    }
}
