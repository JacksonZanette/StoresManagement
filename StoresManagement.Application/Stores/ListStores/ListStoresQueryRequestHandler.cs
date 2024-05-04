using MediatR;
using StoresManagement.Application.Stores.GetStore;
using StoresManagement.Domain.Repositories;

namespace StoresManagement.Application.Stores.ListStores;

internal class ListStoresQueryRequestHandler(IStoresRepository repository)
    : IRequestHandler<ListStoresQueryRequest, IEnumerable<GetStoreResponse>>
{
    public async Task<IEnumerable<GetStoreResponse>> Handle(ListStoresQueryRequest request, CancellationToken cancellationToken)
    {
        var stores = await repository.GetAsync(cancellationToken);
        return stores.Select(GetStoreResponse.FromEntity);
    }
}