using WebApp.Models.ViewFilter;
using WebApp.Repositories;

namespace WebApp.Services
{
    public abstract class BaseService<T1, T2> : IService<T1>
        where T1 : class
        where T2 : class
    {
        private readonly IRepo<T2> _repo;

        protected BaseService(IRepo<T2> repo)
        {
            _repo = repo;
        }

        public IRepo<T2> Repository => _repo;

        public abstract Task DeleteAsync(long id);

        public abstract Task<List<T1>> GetAllAsync(IFilter filter);

        public abstract Task<T1?> GetByIdAsync(long id);

        public abstract Task<long> InsertAsync(T1 entity);

        public abstract Task UpdateAsync(T1 entity);
    }
}
