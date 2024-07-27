using System.Data;
using Geolocations.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Geolocations.Persistence;

public sealed class GeolocationsDbContext(DbContextOptions<GeolocationsDbContext> options) : DbContext(options)
{
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<City> Cities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Currency>(e =>
        {
            e.Property(c => c.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
            e.Property(c => c.ISOCode).HasColumnType("varchar").HasMaxLength(3);
            e.Property(c => c.ISONumber).HasColumnType("numeric(3,0)");
            e.Property(c => c.ShortName).HasColumnType("varchar").HasMaxLength(20);
            e.Property(c => c.FullName).HasColumnType("varchar").HasMaxLength(255);
            e.Property(c => c.Symbol).HasColumnType("varchar").HasMaxLength(5);
            e.HasIndex(c => c.ISOCode).IsUnique();
            e.HasIndex(c => c.ISONumber).IsUnique();
        });

        modelBuilder.Entity<Country>(e =>
        {
            e.Property(c => c.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
            e.Property(c => c.ISO2).HasColumnType("varchar").HasMaxLength(3);
            e.Property(c => c.ISO3).HasColumnType("varchar").HasMaxLength(3);
            e.Property(c => c.ISONumber).HasColumnType("numeric(3,0)");
            e.Property(c => c.Name).HasColumnType("varchar").HasMaxLength(255);
            e.Property(c => c.Capital).HasColumnType("varchar").HasMaxLength(255);
            e.Property(c => c.WebDomain).HasColumnType("varchar").HasMaxLength(10);
            e.Property(c => c.PhoneCode).HasColumnType("varchar").HasMaxLength(10);

            e.HasOne(c => c.Currency);

            e.HasIndex(
                nameof(Country.Name),
                nameof(Country.ISO2),
                nameof(Country.ISO3),
                nameof(Country.ISONumber)
            ).IsUnique();
        });

        modelBuilder.Entity<Region>(e =>
        {
            e.Property(r => r.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
            e.Property(r => r.Name).HasColumnType("varchar").HasMaxLength(255);
            e.Property(r => r.ZipCode).HasColumnType("varchar").HasMaxLength(50);

            e.HasMany(r => r.Cities).WithOne(c => c.Region);
            e.HasIndex(r => r.Name).IsUnique();
        });


        modelBuilder.Entity<City>(e =>
        {
            e.Property(c => c.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
            e.Property(c => c.Name).HasColumnType("varchar").HasMaxLength(255);
            e.Property(c => c.ZipCode).HasColumnType("varchar").HasMaxLength(50);

            e.HasOne(c => c.Region).WithMany(r => r.Cities);
            e.HasIndex(r => r.Name).IsUnique();
        });
    }
}
