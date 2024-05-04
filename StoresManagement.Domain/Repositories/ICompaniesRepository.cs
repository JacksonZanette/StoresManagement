using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Domain.Repositories;

public interface ICompaniesRepository
{
    Task AddAsync(Company company, CancellationToken cancellationToken = default);

    Task<Company?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<Company>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<bool> Exists(Guid id, CancellationToken cancellationToken = default);
}