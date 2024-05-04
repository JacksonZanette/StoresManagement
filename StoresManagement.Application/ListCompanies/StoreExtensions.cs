using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Application.ListCompanies;

public static class StoreExtensions
{
    public static StoreResponseWithinCompanyDto ToResponseWithinCompanyDto(this Store store)
        => new(store.Id, store.Name, store.Address);
}