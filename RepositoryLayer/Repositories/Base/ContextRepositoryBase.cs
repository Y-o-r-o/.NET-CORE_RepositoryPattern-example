using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Databases.Cache;
using RepositoryLayer.Databases.Configuration;
using System.Linq.Expressions;

namespace RepositoryLayer.Repositories.Base;

internal abstract class ContextRepositoryBase<TEntity> : RepositoryBase
    where TEntity : class
{
    protected readonly DataContext _context;

    protected IQueryable<TEntity> Entities { get; set; }

    protected ContextRepositoryBase(DataContext context, CacheFactory cacheFactory) : base(cacheFactory)
    {
        _context = context;
        Entities = context.Set<TEntity>();
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CacheParams? cacheParams = null)
    {
        return await HandleCaching(() => Entities.FirstOrDefaultAsync(predicate), cacheParams);
    }

    public virtual async Task<IEnumerable<TEntity?>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, CacheParams? cacheParams = null)
    {
        if (predicate is null) return await HandleCaching(() => Entities.ToListAsync(), cacheParams);
        return await HandleCaching(() => Entities.Where(predicate).ToListAsync(), cacheParams);
    }

    public virtual async Task<bool> RemoveAsync(TEntity entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
}