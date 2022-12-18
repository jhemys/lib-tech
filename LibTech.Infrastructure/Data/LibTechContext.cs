using LibTech.Domain;
using LibTech.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace LibTech.Infrastructure.Data
{
    public class LibTechContext : DbContext, IUnitOfWork
    {
        public LibTechContext(DbContextOptions<LibTechContext> options)
            : base(options)
        {
        }

        public DbSet<VendingMachine> VendingMachines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendingMachineConfiguration).Assembly);
        }

        public async Task SaveEntitiesAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}
