using System.Threading.Tasks;

namespace LibTech.Domain.SeedWork
{
    public interface IRepository<TModel> where TModel : IEntity
    {
        IUnitOfWork UnitOfWork { get; }

        Task AddAsync(TModel model);
        void Remove(TModel model);
        void Update(TModel model);
    }
}
