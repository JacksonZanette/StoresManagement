using MediatR;

namespace StoresManagement.Application.Stores.GetStore;
public sealed record GetStoreQueryRequest(Guid Id) : IRequest<GetStoreResponse?>
{
}