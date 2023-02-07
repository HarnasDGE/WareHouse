
using Lager.Entities;
using Lager.Repositories;

namespace Lager.Repositories
{
    public interface IReadRepository<out T>
        where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
    }
}
