using MediatR;

namespace StoresManagement.Application.Stores.Get;
public sealed record GetStoreQueryRequest(Guid Id) : IRequest<GetStoreResponse?>
{
}