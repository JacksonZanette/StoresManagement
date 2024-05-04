using MediatR;
using StoresManagement.Application.GetCompany;

namespace StoresManagement.Application.ListCompanies;
public sealed record ListCompaniesQueryRequest : IRequest<IEnumerable<GetCompanyResponse>>
{
}