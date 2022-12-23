using LibTech.Domain;
using LibTech.Infrastructure.Data;

namespace LibTech.Infrastructure.Repositories
{
    public class VendingMachineRepository : Repository<VendingMachine>, IVendingMachineRepository
    {
        public VendingMachineRepository(LibTechContext context) : base(context)
        {
        }
    }
}
