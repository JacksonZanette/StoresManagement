using StoresManagement.Domain.Models.Entities;
using StoresManagement.Domain.Models.ValueObjects;

namespace StoresManagement.Application.GetCompany;
public sealed record StoreWithinCompanyDto(Guid Id, string Name, Address Address)
{
    public static StoreWithinCompanyDto FromEntity(Store store)
        => new(store.Id, store.Name, store.Address);
}