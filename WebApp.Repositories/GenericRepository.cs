using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using WebApp.Database;
using WebApp.Models.Database;

namespace WebApp.Repositories
{
    //public class GenericRepository<T> : IRepo<T> where T : class, IEntity
    //{
    //    private readonly AppDbContext _context;
    //    private readonly DbSet<T> _dbSet;

    //    public GenericRepository(AppDbContext context)
    //    {
    //        _context = context;
    //        _dbSet = context.Set<T>();
    //    }

    //    public virtual Task<List<TResult>> GetAsync<TResult>(Expression<Func<T, TResult>> selector, IEnumerable<Expression<Func<T, bool>>>? filters = null)
    //        where TResult : class
    //    {
    //        var query = _dbSet.AsQueryable();

    //        if (filters is not null && filters.Any())
    //        {
    //            query = filters.Aggregate(_dbSet.AsQueryable(), (items, filter) => items.Where(filter));
    //        }

    //        return query
    //           .Select(selector)
    //           .ToListAsync();
    //    }

    //    public virtual Task<TResult?> GetByIdAsync<TResult>(object id, Expression<Func<T, TResult>> selector)
    //        where TResult : class
    //        => _dbSet
    //        .Where(i => i.Identifier == id)
    //        .Select(selector)
    //        .SingleOrDefaultAsync();

    //    public virtual async Task<object> InsertAsync(T entity)
    //    {
    //        _dbSet.Add(entity);
    //        await _context.SaveChangesAsync();

    //        return entity.Identifier;
    //    }

    //    public virtual async Task UpdateAsync(T entity)
    //    {
    //        _dbSet.Attach(entity);
    //        _context.Entry(entity).State = EntityState.Modified;
    //        await _context.SaveChangesAsync();
    //    }

    //    public virtual async Task DeleteAsync(object id)
    //    {
    //        var obj = await _dbSet.FindAsync(id);

    //        if (obj != null)
    //        {
    //            _dbSet.Remove(obj);
    //            await _context.SaveChangesAsync();
    //        }
    //    }
    //}
}
