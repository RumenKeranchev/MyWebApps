using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WebApp.Repositories
{
    public interface IRepo<TModel> where TModel : class
    {
        Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<TModel, TResult>> selector, Expression<Func<TModel, bool>> filter) where TResult : class;

        Task<TResult?> GetByIdAsync<TResult>(long id, Expression<Func<TModel, TResult>> selector) where TResult : class;

        Task<long> InsertAsync(TModel entity);

        Task UpdateAsync(TModel entity);

        Task DeleteAsync(long id);
    }
}