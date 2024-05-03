using StoresManagement.Domain.Models.Entities;

namespace StoresManagement.Domain.Repositories;

public interface ICompanyRepository
{
    Task CreateAsync(Company company, CancellationToken cancellationToken);
}