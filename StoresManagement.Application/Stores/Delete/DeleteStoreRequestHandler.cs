using MediatR;
using StoresManagement.Core.Common;
using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Application.Stores.Delete;

internal class DeleteStoreRequestHandler(IRepository<Store> repository) : IRequestHandler<DeleteStoreRequest>
{
    public async Task Handle(DeleteStoreRequest request, CancellationToken cancellationToken)
        => await repository.DeleteByIdAsync(request.Id, cancellationToken);
}