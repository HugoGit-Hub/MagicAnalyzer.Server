using Domain;
using Domain.Exceptions;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class Repository<TEntity, TId> (MagicAnalyzerContext context)
    : IRepository<TEntity, TId> where TEntity : class
{
    public async Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken)
    {
        var result = await context.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return result.Entity;
    }

    public async Task<TEntity> Get(TId id, CancellationToken cancellationToken)
    {
        var result = await context.Set<TEntity>()
            .FindAsync([id], cancellationToken) ?? throw new NotFoundException($"Unable to get requiered entity {typeof(TEntity).Name}");
        context.Entry(result).State = EntityState.Detached;

        return result;
    }

    public async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken)
    {
        return await context
            .Set<TEntity>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
    {
        var result = context.Update(entity);
        await context.SaveChangesAsync(cancellationToken);

        return result.Entity;
    }

    public async Task<TEntity> Delete(TEntity entity, CancellationToken cancellationToken)
    {
        var result = context.Remove(entity);
        await context.SaveChangesAsync(cancellationToken);

        return result.Entity;
    }
}