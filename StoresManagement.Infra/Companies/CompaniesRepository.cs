using Microsoft.EntityFrameworkCore;
using StoresManagement.Domain.Models.Entities;
using StoresManagement.Domain.Repositories;

namespace StoresManagement.Infra.Companies;

internal class CompaniesRepository(StoresManagementContext context) : ICompaniesRepository
{
    public async Task AddAsync(Company company, CancellationToken cancellationToken = default)
    {
        await context.Companies.AddAsync(company, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> Exists(Guid id, CancellationToken cancellationToken = default)
        => await context.Companies.AnyAsync(e => e.Id == id, cancellationToken);

    public async Task<Company?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Companies.Include(e => e.Stores).FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

    public async Task<IEnumerable<Company>> GetAsync(CancellationToken cancellationToken = default)
        => await context.Companies.Include(e => e.Stores).ToArrayAsync(cancellationToken);
}