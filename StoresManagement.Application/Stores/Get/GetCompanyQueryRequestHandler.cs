using MediatR;
using StoresManagement.Core.Common;
using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Application.Stores.Get;

internal class GetStoreQueryRequestHandler(IRepository<Store> repository) : IRequestHandler<GetStoreQueryRequest, GetStoreResponse?>
{
    public async Task<GetStoreResponse?> Handle(GetStoreQueryRequest request, CancellationToken cancellationToken)
    {
        var Store = await repository.FindAsync(request.Id, cancellationToken);

        return Store is not null
            ? GetStoreResponse.FromEntity(Store)
            : default;
    }
}