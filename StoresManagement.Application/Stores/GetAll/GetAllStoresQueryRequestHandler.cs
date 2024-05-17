using MediatR;
using StoresManagement.Application.Stores.Get;
using StoresManagement.Core.Common;
using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Application.Stores.GetAll;

internal class GetAllStoresQueryRequestHandler(IRepository<Store> repository)
    : IRequestHandler<GetAllStoresQueryRequest, IEnumerable<GetStoreResponse>>
{
    public async Task<IEnumerable<GetStoreResponse>> Handle(GetAllStoresQueryRequest request, CancellationToken cancellationToken)
    {
        var stores = await repository.FindAllAsync(cancellationToken);
        return stores.Select(GetStoreResponse.FromEntity);
    }
}