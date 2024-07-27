using Geolocations.Domain.Entities;
using Geolocations.Persistence.EntityConfigurations;
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
        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.GetAssembly());
    }
}
