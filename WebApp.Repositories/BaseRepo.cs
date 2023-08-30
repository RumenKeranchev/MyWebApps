using System.Linq.Expressions;
using WebApp.Models.Database;

namespace WebApp.Repositories
{
    public abstract class BaseRepo<T> : IRepo<T> where T : class, IEntity
    {
        public abstract Task DeleteAsync(object id);

        public abstract Task<List<TResult>> GetAsync<TResult>(Expression<Func<T, TResult>> selector, IEnumerable<Expression<Func<T, bool>>>? filters = null)
            where TResult : class;

        public abstract Task<TResult?> GetByIdAsync<TResult>(object id, Expression<Func<T, TResult>> selector) where TResult : class;

        public abstract Task<object> InsertAsync(T entity);

        public abstract Task UpdateAsync(T entity);
    }
}
