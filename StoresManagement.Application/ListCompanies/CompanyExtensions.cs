using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Application.ListCompanies;

public static class CompanyExtensions
{
    public static CompanyResponseDto ToResponseDto(this Company company)
        => new(company.Id, company.Name, company.Stores.Select(e => e.ToResponseWithinCompanyDto()));
}