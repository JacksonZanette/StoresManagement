using MediatR;
using StoresManagement.Application.Companies.Get;
using StoresManagement.Core.Common;
using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Application.Companies.GetAll;

internal class GetAllCompaniesQueryRequestHandler(IRepository<Company> repository)
    : IRequestHandler<GetAllCompaniesQueryRequest, IEnumerable<GetCompanyResponse>>
{
    public async Task<IEnumerable<GetCompanyResponse>> Handle(GetAllCompaniesQueryRequest request, CancellationToken cancellationToken)
    {
        var companies = await repository.FindAllAsync(cancellationToken);
        return companies.Select(GetCompanyResponse.FromEntity);
    }
}