using WebApp.Models.Database;
using WebApp.Models.ViewFilter;
using WebApp.Repositories;

namespace WebApp.Services
{
    public interface IService<TDto, TModel> 
        where TDto : class
        where TModel : class, IEntity
    {
        Task<List<TDto>> GetAsync(IFilter<TModel> filter);

        Task<TDto?> GetByIdAsync(long id);

        Task<long> InsertAsync(TDto entity);

        Task UpdateAsync(TDto entity);

        Task DeleteAsync(long id);
    }
}