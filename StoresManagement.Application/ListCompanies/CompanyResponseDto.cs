namespace StoresManagement.Application.ListCompanies;
public sealed record CompanyResponseDto(Guid Id, string Name, IEnumerable<StoreResponseWithinCompanyDto> Stores)
{
}