using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace UseNotify.Repositories;

public class RepositoryBase<TEntity, TEntityId, TDbContext> : IRepositoryBase<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TDbContext : DbContext {

    protected readonly TDbContext _dbContext;
    public RepositoryBase(TDbContext dbContext) {
        _dbContext = dbContext;
    }

    public IQueryable<TEntity> Query() => _dbContext.Set<TEntity>();

    public async Task<TEntity> AddAsync(TEntity entity) {
        entity.CreatedAt = DateTime.UtcNow;
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default) {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking)
            queryable = queryable.AsNoTracking();
        if (include != null)
            queryable = include(queryable);
        if (withDeleted)
            queryable = queryable.IgnoreQueryFilters();
        if (predicate != null)
            queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToListAsync(cancellationToken);
        return await queryable.ToListAsync(cancellationToken);
    }
}
