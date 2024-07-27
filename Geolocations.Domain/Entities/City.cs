namespace Geolocations.Domain.Entities;

public sealed class City
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string ZipCode { get; set; }
    public CityType Type { get; set; }
    public required Region Region { get; set; }
    public List<Street>? Streets { get; set; }
}