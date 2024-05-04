using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Domain.Repositories;

public interface IStoresRepository
{
    Task AddAsync(Store store, CancellationToken cancellationToken = default);

    Task<Store> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Store?>> GetAsync(CancellationToken cancellationToken = default);
}