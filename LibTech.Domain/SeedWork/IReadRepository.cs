using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibTech.Domain.SeedWork
{
    public interface IReadRepository<TEntity> where TEntity : Entity
    {
        public Task<TEntity> GetById(long id);
        public Task<IEnumerable<TEntity>> GetAll();
    }
}
