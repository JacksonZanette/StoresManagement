using StoresManagement.Core.Common;

namespace StoresManagement.Domain.Models.Entities;

public sealed class Company : Entity
{
    public required string Name { get; set; }

    public HashSet<Store> Stores { get; set; } = [];
}