namespace StoresManagement.Domain.Models.Entities;

public sealed class Company
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public HashSet<Store> Stores { get; set; } = [];
}
