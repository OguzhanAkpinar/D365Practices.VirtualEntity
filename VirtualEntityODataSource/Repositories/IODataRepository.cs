using System;
using System.Linq;
using System.Threading.Tasks;
using VirtualEntityODataSource.Data.Entities.Base;

namespace VirtualEntityODataSource.Repositories
{
    public interface IODataRepository<T> where T : EntityBase
    {
        Task<IQueryable<T>> Get();
        Task<T> Get(Guid Id);
        Task<T> Create(T entity);
        Task<T> Update(Guid Id, T entity);
        Task<bool> Delete(Guid Id);
    }
}
