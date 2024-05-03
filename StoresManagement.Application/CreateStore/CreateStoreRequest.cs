using FluentResults;
using MediatR;
using StoresManagement.Domain.Models.ValuedObjects;

namespace StoresManagement.Application.CreateCompany;
public record CreateStoreRequest(Guid CompanyId, string Name, Address Address) : IRequest<Result<Guid>>
{
}