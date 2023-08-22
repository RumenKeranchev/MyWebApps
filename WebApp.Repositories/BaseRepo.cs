using System.Linq.Expressions;
using WebApp.Models.Database;

namespace WebApp.Repositories
{
    public abstract class BaseRepo<T> : IRepo<T> where T : class
    {
        public abstract Task DeleteAsync(long id);

        public abstract Task<List<TResult>> GetAsync<TResult>(Expression<Func<T, TResult>> selector, IEnumerable<Expression<Func<T, bool>>> filters)
            where TResult : class;

        public abstract Task<TResult?> GetByIdAsync<TResult>(long id, Expression<Func<T, TResult>> selector) where TResult : class;

        public abstract Task<long> InsertAsync(T entity);

        public abstract Task UpdateAsync(T entity);
    }
}
