using MediatR;

namespace StoresManagement.Application.Stores.DeleteStore;
public sealed record DeleteStoreRequest(Guid Id) : IRequest
{
}