using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Databases.Configuration;
using System.Linq.Expressions;

namespace RepositoryLayer.Repositories.Base;

internal abstract class ContextRepositoryBase<TEntity>
    where TEntity : class
{
    protected readonly DataContext _context;

    protected IQueryable<TEntity> Entities { get; set; }

    protected ContextRepositoryBase(DataContext context)
    {
        _context = context;
        Entities = context.Set<TEntity>();
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        => await Entities.FirstOrDefaultAsync(predicate);

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        if (predicate is null) return await Entities.ToListAsync();
        return await Entities.Where(predicate).ToListAsync();
    }

    public virtual async Task RemoveAsync(TEntity entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
}