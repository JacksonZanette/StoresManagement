using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Domain.Repositories;

public interface IStoresRepository
{
    Task AddAsync(Store store, CancellationToken cancellationToken = default);
}