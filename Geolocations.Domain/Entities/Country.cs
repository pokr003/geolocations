namespace Geolocations.Domain.Entities;

public sealed class Country
{
    public Guid Id { get; set; }
    public int ISONumber { get; set; }
    public required string ISO2 { get; set; }
    public required string ISO3 { get; set; }
    public required string Name { get; set; }
    public required string Capital { get; set; }
    public required Currency Currency { get; set; }
    public required string WebDomain { get; set; }
    public required string PhoneCode { get; set; }
    public List<Region>? Regions { get; set; }
}
