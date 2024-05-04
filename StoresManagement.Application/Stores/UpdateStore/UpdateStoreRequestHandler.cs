using FluentResults;
using MediatR;
using StoresManagement.Domain.Repositories;

namespace StoresManagement.Application.Stores.UpdateStore;

internal class UpdateStoreRequestHandler(IStoresRepository storesRepository, ICompaniesRepository companiesRepository)
    : IRequestHandler<UpdateStoreRequest, Result>
{
    public async Task<Result> Handle(UpdateStoreRequest request, CancellationToken cancellationToken)
    {
        var store = await storesRepository.GetAsync(request.Id, cancellationToken);

        if (store is null)
            return Result.Fail("NotFound");

        var validation = request.Validate();

        if (!validation.IsValid)
            return Result.Fail(validation.Errors.Select(e => e.ErrorMessage));

        if (!await companiesRepository.Exists(request.CompanyId!.Value, cancellationToken))
            return Result.Fail("The company id provided doesn't match with any existent company.");

        store.Name = request.Name!;
        store.CompanyId = request.CompanyId!.Value;
        store.Address = request.Address!;

        await storesRepository.UpdateAsync(store, cancellationToken);

        return Result.Ok();
    }
}