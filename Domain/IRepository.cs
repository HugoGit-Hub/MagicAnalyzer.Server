namespace Domain;

public interface IRepository<TEntity, in TId>
{
    Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken);

    Task<TEntity> Get(TId id, CancellationToken cancellationToken);

    Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken);

    Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken);

    Task<TEntity> Delete(TEntity entity, CancellationToken cancellationToken);
}