using WebApp.Models.Database;
using WebApp.Models.ViewFilter;
using WebApp.Repositories;

namespace WebApp.Services
{
    public abstract class BaseService<TDto, TModel> : IService<TDto, TModel>
        where TDto : class
        where TModel : class, IEntity
    {
        private readonly IRepo<TModel> _repo;

        protected BaseService(IRepo<TModel> repo)
        {
            _repo = repo;
        }

        public IRepo<TModel> Repository => _repo;

        public abstract Task DeleteAsync(long id);

        public abstract Task<List<TDto>> GetAsync(IFilter<TModel> filter);

        public abstract Task<TDto?> GetByIdAsync(long id);

        public abstract Task<long> InsertAsync(TDto entity);

        public abstract Task UpdateAsync(TDto entity);
    }
}
