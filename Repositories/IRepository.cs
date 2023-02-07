using Lager.Entities;


namespace Lager.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : class, IEntity
    {   
    }
}

