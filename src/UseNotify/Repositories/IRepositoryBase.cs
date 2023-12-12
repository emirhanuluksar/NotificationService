using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace UseNotify.Repositories;

public interface IRepositoryBase<TEntity, TEntityId>
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<IList<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
}
