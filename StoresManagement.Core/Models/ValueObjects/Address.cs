namespace StoresManagement.Domain.Models.ValueObjects;

public sealed record Address(string StreetName, string CityName, string RegionName, string PostalCode, string Country) { }