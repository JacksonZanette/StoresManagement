using MediatR;

namespace StoresManagement.Application.Companies.Get;
public sealed record GetCompanyQueryRequest(Guid Id) : IRequest<GetCompanyResponse?>
{
}