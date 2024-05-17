namespace StoresManagement.Core.Common;

public interface IRepository<TEntity> where TEntity : Entity
{
    public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    public Task<bool> Exists(Guid id, CancellationToken cancellationToken = default);

    public Task<TEntity?> FindAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken = default);

    public void Update(TEntity entity);

    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task CommitAsync(CancellationToken cancellationToken = default);
}