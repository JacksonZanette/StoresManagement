namespace StoresManagement.Domain.Models.ValuedObjects;

public sealed record Address
{
    public required string StreetName { get; set; }
    public required string CityName { get; set; }
    public required string RegionName { get; set; }
    public required string PostalCode { get; set; }
    public required string Country { get; set; }
}