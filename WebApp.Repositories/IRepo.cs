using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Models.Database;

namespace WebApp.Repositories
{
    public interface IRepo<TModel> where TModel : class, IEntity
    {
        Task<List<TResult>> GetAsync<TResult>(Expression<Func<TModel, TResult>> selector, IEnumerable<Expression<Func<TModel, bool>>>? filters = null) where TResult : class;

        Task<TResult?> GetByIdAsync<TResult>(object id, Expression<Func<TModel, TResult>> selector) where TResult : class;

        Task<object> InsertAsync(TModel entity);

        Task UpdateAsync(TModel entity);

        Task DeleteAsync(object id);
    }
}