namespace StoresManagement.Domain.Models.ValuedObjects;

public sealed record Address(string StreetName, string CityName, string RegionName, string PostalCode, string Country) { }