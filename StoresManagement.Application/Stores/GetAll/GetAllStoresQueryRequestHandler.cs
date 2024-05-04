using MediatR;
using StoresManagement.Application.Stores.Get;
using StoresManagement.Domain.Repositories;

namespace StoresManagement.Application.Stores.GetAll;

internal class GetAllStoresQueryRequestHandler(IStoresRepository repository)
    : IRequestHandler<GetAllStoresQueryRequest, IEnumerable<GetStoreResponse>>
{
    public async Task<IEnumerable<GetStoreResponse>> Handle(GetAllStoresQueryRequest request, CancellationToken cancellationToken)
    {
        var stores = await repository.GetAllAsync(cancellationToken);
        return stores.Select(GetStoreResponse.FromEntity);
    }
}