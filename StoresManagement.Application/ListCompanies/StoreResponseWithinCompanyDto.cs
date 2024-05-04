using StoresManagement.Domain.Models.ValueObjects;

namespace StoresManagement.Application.ListCompanies;
public sealed record StoreResponseWithinCompanyDto(Guid Id, string Name, Address Address)
{
}