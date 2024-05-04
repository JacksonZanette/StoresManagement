using MediatR;

namespace StoresManagement.Application.Companies.GetCompany;
public sealed record GetCompanyQueryRequest(Guid Id) : IRequest<GetCompanyResponse?>
{
}