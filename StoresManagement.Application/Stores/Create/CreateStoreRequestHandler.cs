using FluentResults;
using MediatR;
using StoresManagement.Application.Extensions;
using StoresManagement.Core.Common;
using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Application.Stores.Create;

public class CreateStoreRequestHandler(IRepository<Company> companiesRepository, IRepository<Store> storesRepository)
    : IRequestHandler<CreateStoreRequest, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateStoreRequest request, CancellationToken cancellationToken)
    {
        var validationResult = request.Validate();

        if (!validationResult.IsValid)
            return validationResult.ToFluentResult();

        if (!await companiesRepository.Exists(request.CompanyId!.Value, cancellationToken))
            return Result.Fail("The company id provided doesn't match with any existent company.");

        var store = request.ToEntity();

        await storesRepository.AddAsync(store, cancellationToken);
        await storesRepository.CommitAsync(cancellationToken);

        return Result.Ok(store.Id);
    }
}