using MediatR;
using StoresManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoresManagement.Application.Stores.DeleteStore;

internal class DeleteStoreRequestHandler(IStoresRepository repository) : IRequestHandler<DeleteStoreRequest>
{
    public async Task Handle(DeleteStoreRequest request, CancellationToken cancellationToken)
        => await repository.DeleteByIdAsync(request.Id, cancellationToken);
}