using LibTech.Domain.SeedWork;

namespace LibTech.SharedKernel.Interfaces
{
    public interface IRepository<TModel> where TModel : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

        Task<TModel> GetById(long id);
        Task AddAsync(TModel model);
        void Remove(TModel model);
        void Update(TModel model);
        Task Save(TModel model);
    }
}