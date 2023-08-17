using System.Linq.Expressions;
using WebApp.Models.ViewFilter;

namespace WebApp.Services
{
    public interface IService<T> where T : class
    {
        Task<List<T>> GetAllAsync(IFilter filter);

        Task<T?> GetByIdAsync(long id);

        Task<long> InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(long id);
    }
}