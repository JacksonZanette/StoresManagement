using MediatR;

namespace StoresManagement.Application.Stores.Delete;
public sealed record DeleteStoreRequest(Guid Id) : IRequest
{
}