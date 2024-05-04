using MediatR;

namespace StoresManagement.Application.ListCompanies;
public sealed record ListCompaniesQueryRequest : IRequest<IEnumerable<CompanyResponseDto>>
{
}