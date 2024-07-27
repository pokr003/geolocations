namespace Geolocations.Domain.Entities;

public sealed class Street
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required City City { get; set; }
}