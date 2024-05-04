using MediatR;
using StoresManagement.Application.Companies.Get;
using StoresManagement.Domain.Repositories;

namespace StoresManagement.Application.Companies.GetAll;

internal class GetAllCompaniesQueryRequestHandler(ICompaniesRepository repository)
    : IRequestHandler<GetAllCompaniesQueryRequest, IEnumerable<GetCompanyResponse>>
{
    public async Task<IEnumerable<GetCompanyResponse>> Handle(GetAllCompaniesQueryRequest request, CancellationToken cancellationToken)
    {
        var companies = await repository.GetAllAsync(cancellationToken);
        return companies.Select(GetCompanyResponse.FromEntity);
    }
}