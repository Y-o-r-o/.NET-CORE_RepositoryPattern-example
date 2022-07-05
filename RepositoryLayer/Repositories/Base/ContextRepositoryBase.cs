using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Databases.Configuration;
using System.Linq.Expressions;

namespace RepositoryLayer.Repositories.Base;
internal abstract class ContextRepositoryBase<TEntity>
{
    protected readonly DataContext _context;

    protected IQueryable<TEntity> Entities { get; set; }

    protected ContextRepositoryBase(DataContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        => await Entities.FirstOrDefaultAsync(predicate);

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
