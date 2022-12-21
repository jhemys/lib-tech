using LibTech.Domain.SeedWork;
using LibTech.Infrastructure.Data;
using LibTech.SharedKernel;
using LibTech.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibTech.Infrastructure.Repositories
{
    public class WriteRepository<T> : IRepository<T> where T : Entity
    {
        private readonly LibTechContext _context;
        private readonly DbSet<T> _entity;
        public WriteRepository(LibTechContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task AddAsync(T model)
        {
            await _entity.AddAsync(model);
            await _context.SaveEntitiesAsync();
        }

        public void Remove(T model)
        {
            _entity.Attach(model);
            _entity.Remove(model);
        }

        public void Update(T model)
        {
            _entity.Attach(model);
            _entity.Entry(model).State = EntityState.Modified;
        }
    }
}
