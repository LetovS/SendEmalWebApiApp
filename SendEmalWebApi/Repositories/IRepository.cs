using SendEmalWebApi.Model;

namespace SendEmalWebApi.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        public Task<List<T>> GetAll();
        public Task Create(T model);
    }
}
