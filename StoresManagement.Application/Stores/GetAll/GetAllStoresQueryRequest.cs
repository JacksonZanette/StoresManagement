using MediatR;
using StoresManagement.Application.Stores.Get;

namespace StoresManagement.Application.Stores.GetAll;
public sealed record GetAllStoresQueryRequest : IRequest<IEnumerable<GetStoreResponse>>
{
}