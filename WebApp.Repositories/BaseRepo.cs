using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Repositories
{
    public abstract class BaseRepo<T> : IRepo<T> where T : class
    {
        public abstract Task DeleteAsync(long id);

        public abstract Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> filter) where TResult : class;

        public abstract Task<TResult?> GetByIdAsync<TResult>(long id, Expression<Func<T, TResult>> selector) where TResult : class;

        public abstract Task<long> InsertAsync(T entity);

        public abstract Task UpdateAsync(T entity);
    }
}
