using System.Linq.Expressions;

namespace WebApp.Repositories
{
    public interface IRepo<T> where T : class
    {
        Task<List<T>> GetAllAsync();

        IQueryable<T> GetAllQueryable();

        Task<List<T>> GetAllFilteredAsync(Expression<Func<T, bool>> filter);

        IQueryable<T> FindAllQueryable(Expression<Func<T, bool>> filter);

        Task<T?> GetByIdAsync(long id);

        Task<long> InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(long id);
    }
}