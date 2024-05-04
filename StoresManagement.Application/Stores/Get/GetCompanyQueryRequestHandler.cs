using MediatR;
using StoresManagement.Domain.Repositories;

namespace StoresManagement.Application.Stores.Get;

internal class GetStoreQueryRequestHandler(IStoresRepository repository) : IRequestHandler<GetStoreQueryRequest, GetStoreResponse?>
{
    public async Task<GetStoreResponse?> Handle(GetStoreQueryRequest request, CancellationToken cancellationToken)
    {
        var Store = await repository.GetAsync(request.Id, cancellationToken);

        return Store is not null
            ? GetStoreResponse.FromEntity(Store)
            : default;
    }
}