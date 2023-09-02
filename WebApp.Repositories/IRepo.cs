using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Models.Database;

namespace WebApp.Repositories
{
    public interface IRepo<TModel> where TModel : class
    {
        Task<List<TResult>> GetAsync<TResult>(Expression<Func<TModel, TResult>> selector, IEnumerable<Expression<Func<TModel, bool>>>? filters = null) where TResult : class;

        Task<TResult?> GetByIdAsync<TResult>(long id, Expression<Func<TModel, TResult>> selector) where TResult : class;

        Task<long> InsertAsync(TModel entity);

        Task UpdateAsync(TModel entity);

        Task DeleteAsync(long id);
    }
}