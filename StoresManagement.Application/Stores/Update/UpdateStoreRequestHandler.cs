using FluentResults;
using MediatR;
using StoresManagement.Core.Common;
using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Application.Stores.Update;

internal class UpdateStoreRequestHandler(IRepository<Store> storesRepository, IRepository<Company> companiesRepository)
    : IRequestHandler<UpdateStoreRequest, Result>
{
    public async Task<Result> Handle(UpdateStoreRequest request, CancellationToken cancellationToken)
    {
        var store = await storesRepository.FindAsync(request.Id, cancellationToken);

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

        storesRepository.Update(store);
        await storesRepository.CommitAsync(cancellationToken);

        return Result.Ok();
    }
}