using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualEntityODataSource.Data;
using VirtualEntityODataSource.Data.Entities.Base;

namespace VirtualEntityODataSource.Repositories
{
    public class ODataRepository<T> : IODataRepository<T> where T : EntityBase
    {
        private readonly VirtualEntityDbContext _virtualEntityDbContext;

        public ODataRepository(VirtualEntityDbContext virtualEntityDbContext)
        {
            _virtualEntityDbContext = virtualEntityDbContext;
        }

        public async Task<IQueryable<T>> Get()
        {
            List<T> entities = await _virtualEntityDbContext.Set<T>().ToListAsync();
            return entities.AsQueryable();
        }

        public Task<T> Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(Guid Id, T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid Id)
        {
            if (_virtualEntityDbContext.Set<T>().Any(x => x.Id == Id))
            {
                T entity = await _virtualEntityDbContext.Set<T>().FindAsync(Id);
                _virtualEntityDbContext.Set<T>().Remove(entity);
                await _virtualEntityDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
