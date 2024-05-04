using MediatR;
using StoresManagement.Domain.Repositories;

namespace StoresManagement.Application.GetCompany;

internal class GetCompanyQueryRequestHandler(ICompaniesRepository repository) : IRequestHandler<GetCompanyQueryRequest, GetCompanyResponse?>
{
    public async Task<GetCompanyResponse?> Handle(GetCompanyQueryRequest request, CancellationToken cancellationToken)
    {
        var company = await repository.GetAsync(request.Id, cancellationToken);

        return company is not null
            ? GetCompanyResponse.FromEntity(company)
            : default;
    }
}