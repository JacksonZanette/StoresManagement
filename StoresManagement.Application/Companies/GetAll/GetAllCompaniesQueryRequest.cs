using MediatR;
using StoresManagement.Application.Companies.Get;

namespace StoresManagement.Application.Companies.GetAll;
public sealed record GetAllCompaniesQueryRequest : IRequest<IEnumerable<GetCompanyResponse>>
{
}