using StoresManagement.Core.Common;
using StoresManagement.Domain.Models.ValueObjects;

namespace StoresManagement.Domain.Models.Entities;

public sealed class Store : Entity
{
    public Guid CompanyId { get; set; }
    public required string Name { get; set; }
    public required Address Address { get; set; }

    public Company? Company { get; set; }
}