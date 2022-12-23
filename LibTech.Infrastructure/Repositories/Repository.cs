using LibTech.Domain.SeedWork;
using LibTech.Infrastructure.Data;
using LibTech.SharedKernel;
using LibTech.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibTech.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : AggregateRoot
    {
        private readonly LibTechContext _context;
        private readonly DbSet<T> _entity;
        public Repository(LibTechContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<T> GetById(int id)
        {
            return await _entity.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<T>> GetAll() => await _entity.ToListAsync();


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

        public async Task Save(T model)
        {
            if(model.Id <= 0)
            {
                await _entity.AddAsync(model);
            }
            else
            {
                _entity.Attach(model);
                _entity.Entry(model).State = EntityState.Modified;
            }

            await _context.SaveEntitiesAsync();
        }
    }
}
