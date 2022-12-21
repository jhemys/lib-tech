using LibTech.Domain.SeedWork;

namespace LibTech.SharedKernel.Interfaces
{
    public interface IReadRepository<TEntity> where TEntity : Entity
    {
        public Task<TEntity> GetById(long id);
        public Task<IEnumerable<TEntity>> GetAll();
    }
}
