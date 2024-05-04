using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Application.Companies.Get;
public sealed record GetCompanyResponse(Guid Id, string Name, IEnumerable<StoreWithinCompanyDto> Stores)
{
    public static GetCompanyResponse FromEntity(Company company)
        => new(company.Id, company.Name, company.Stores.Select(StoreWithinCompanyDto.FromEntity));
}