using Microsoft.EntityFrameworkCore;
using StoresManagement.Core.Common;

namespace StoresManagement.Infrastructure.Common;

public class Repository<TEntity>(DbContext context) : IRepository<TEntity>
    where TEntity : Entity
{
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        => await _dbSet.AddAsync(entity, cancellationToken);

    public async Task<bool> Exists(Guid id, CancellationToken cancellationToken = default)
        => await _dbSet.AnyAsync(e => e.Id == id, cancellationToken);

    public async Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken = default)
        => await _dbSet.ToArrayAsync(cancellationToken);

    public async Task<TEntity?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        => await _dbSet.FindAsync([id], cancellationToken);

    public void Update(TEntity entity)
        => _dbSet.Update(entity);

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var store = await FindAsync(id, cancellationToken);

        if (store is null)
            return;

        _dbSet.Remove(store);
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
        => await context.SaveChangesAsync(cancellationToken);
}