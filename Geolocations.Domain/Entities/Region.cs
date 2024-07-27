namespace Geolocations.Domain.Entities;

public sealed class Region
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string ZipCode { get; set; }
    public required Country Country { get; set; }
    public List<City>? Cities { get; set; }
}
