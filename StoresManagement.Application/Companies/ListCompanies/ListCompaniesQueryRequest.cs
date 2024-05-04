using MediatR;
using StoresManagement.Application.Companies.GetCompany;

namespace StoresManagement.Application.Companies.ListCompanies;
public sealed record ListCompaniesQueryRequest : IRequest<IEnumerable<GetCompanyResponse>>
{
}