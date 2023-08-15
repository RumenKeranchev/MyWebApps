using System.Linq.Expressions;
using WebApp.Models.ViewFilter;

namespace WebApp.Services
{
    public interface IService<T> where T : class
    {
        Task<List<T>> GetAllAsync(IFilter filter);

        Task<T?> GetById(long id);

        Task<long> Insert(T entity);

        Task Update(T entity);

        Task Delete(long id);
    }
}