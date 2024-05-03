using FluentResults;
using MediatR;
using StoresManagement.Domain.Models.Entities;
using StoresManagement.Domain.Models.ValuedObjects;

namespace StoresManagement.Application.CreateStore;
public record CreateStoreRequest(Guid CompanyId, string Name, Address Address) : IRequest<Result<Guid>>
{
    internal Store ToEntity() => throw new NotImplementedException();
}