using MediatR;
using StoresManagement.Domain.Repositories;

namespace StoresManagement.Application.ListCompanies;

internal class ListCompaniesQueryRequestHandler(ICompaniesRepository companiesRepository)
    : IRequestHandler<ListCompaniesQueryRequest, IEnumerable<CompanyResponseDto>>
{
    public async Task<IEnumerable<CompanyResponseDto>> Handle(ListCompaniesQueryRequest request, CancellationToken cancellationToken)
    {
        var companies = await companiesRepository.GetAsync(cancellationToken);
        return companies.Select(e => e.ToResponseDto());
    }
}