using StoresManagement.Domain.Models.Entities;
using StoresManagement.Domain.Repositories;

namespace StoresManagement.Infra.Companies;

internal class CompaniesRepository : ICompaniesRepository
{
    public Task AddAsync(Company company, CancellationToken cancellationToken) => throw new NotImplementedException();
}