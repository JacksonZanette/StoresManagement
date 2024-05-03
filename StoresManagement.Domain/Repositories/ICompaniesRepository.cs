using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Domain.Repositories;

public interface ICompaniesRepository
{
    Task AddAsync(Company company, CancellationToken cancellationToken);
}