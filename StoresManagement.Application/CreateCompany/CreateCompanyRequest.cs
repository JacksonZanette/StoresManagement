using FluentResults;
using MediatR;

namespace StoresManagement.Application.CreateCompany;
public record CreateCompanyRequest(string? Name, IEnumerable<CreateStoreRequest>? Stores = default) : IRequest<Result<Guid>>
{
}