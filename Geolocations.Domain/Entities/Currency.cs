namespace Geolocations.Domain.Entities;

public sealed class Currency
{
    public Guid Id { get; set; }
    public required string ISOCode { get; set; }
    public int ISONumber { get; set; }
    public required string ShortName { get; set; }
    public required string FullName { get; set; }
    public required string Symbol { get; set; }
}