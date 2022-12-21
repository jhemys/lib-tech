using System.Threading.Tasks;

namespace LibTech.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task SaveEntitiesAsync();
    }
}
