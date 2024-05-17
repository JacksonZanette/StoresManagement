using MediatR;
using StoresManagement.Core.Common;
using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Application.Companies.Get;

internal class GetCompanyQueryRequestHandler(IRepository<Company> repository) : IRequestHandler<GetCompanyQueryRequest, GetCompanyResponse?>
{
    public async Task<GetCompanyResponse?> Handle(GetCompanyQueryRequest request, CancellationToken cancellationToken)
    {
        var company = await repository.FindAsync(request.Id, cancellationToken);

        return company is not null
            ? GetCompanyResponse.FromEntity(company)
            : default;
    }
}