using FluentResults;
using MediatR;

namespace StoresManagement.Application.CreateStore;

public class CreateStoreRequestHandler : IRequestHandler<CreateStoreRequest, Result<Guid>>
{
    public Task<Result<Guid>> Handle(CreateStoreRequest request, CancellationToken cancellationToken) => throw new NotImplementedException();
}