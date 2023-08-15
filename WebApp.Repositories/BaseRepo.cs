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

        public abstract IQueryable<T> FindAllQueryable(Expression<Func<T, bool>> filter);

        public abstract Task<List<T>> GetAllAsync();

        public abstract Task<List<T>> GetAllFilteredAsync(Expression<Func<T, bool>> filter);

        public abstract IQueryable<T> GetAllQueryable();

        public abstract Task<T?> GetByIdAsync(long id);

        public abstract Task<long> InsertAsync(T entity);

        public abstract Task UpdateAsync(T entity);
    }
}
