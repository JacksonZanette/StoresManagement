using MediatR;
using StoresManagement.Application.Stores.GetStore;

namespace StoresManagement.Application.Stores.ListStores;
public sealed record ListStoresQueryRequest : IRequest<IEnumerable<GetStoreResponse>>
{
}