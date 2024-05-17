namespace StoresManagement.Infra.Stores;

//internal class StoresRepository(StoresManagementContext context) : IStoresRepository
//{
//    public async Task AddAsync(Store store, CancellationToken cancellationToken = default)
//    {
//        await context.Stores.AddAsync(store, cancellationToken);
//        await context.SaveChangesAsync(cancellationToken);
//    }

//    public async Task<IEnumerable<Store>> GetAllAsync(CancellationToken cancellationToken = default)
//        => await context.Stores.ToArrayAsync(cancellationToken);

//    public async Task<Store?> GetAsync(Guid id, CancellationToken cancellationToken = default)
//        => await context.Stores.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

//    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
//    {
//        var store = await GetAsync(id, cancellationToken);

//        if (store is null)
//            return;

//        context.Stores.Remove(store);
//        await context.SaveChangesAsync(cancellationToken);
//    }

//    public async Task UpdateAsync(Store store, CancellationToken cancellationToken = default)
//    {
//        context.Stores.Update(store);
//        await context.SaveChangesAsync(cancellationToken);
//    }
//}