using MediatR;

namespace StoresManagement.Application.GetCompany;
public sealed record GetCompanyQueryRequest(Guid Id) : IRequest<GetCompanyResponse?>
{
}