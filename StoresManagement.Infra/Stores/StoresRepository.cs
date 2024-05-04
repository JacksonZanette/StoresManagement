﻿using Microsoft.EntityFrameworkCore;
using StoresManagement.Domain.Models.Entities;
using StoresManagement.Domain.Repositories;

namespace StoresManagement.Infra.Stores;

internal class StoresRepository(StoresManagementContext context) : IStoresRepository
{
    public async Task AddAsync(Store store, CancellationToken cancellationToken = default)
    {
        await context.Stores.AddAsync(store, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Store>> GetAsync(CancellationToken cancellationToken = default)
        => await context.Stores.ToArrayAsync(cancellationToken);

    public async Task<Store?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        => await context.Stores.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
}