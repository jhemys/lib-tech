using LibTech.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibTech.Infrastructure.Data
{
    public class LibTechContext : DbContext
    {
        public LibTechContext(DbContextOptions<LibTechContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendingMachineConfiguration).Assembly);
        }

        public DbSet<VendingMachine> VendingMachines { get; set; }
    }
}
