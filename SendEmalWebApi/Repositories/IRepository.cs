using SendEmalWebApi.Model;

namespace SendEmalWebApi.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        public Task<List<T>> GetAll();
        public T Create(T model);
    }
}
