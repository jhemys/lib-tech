using LibTech.Domain;
using LibTech.Infrastructure.Data;

namespace LibTech.Infrastructure.Repositories
{
    public class VendingMachineRepository : WriteRepository<VendingMachine>, IVendingMachineRepository
    {
        public VendingMachineRepository(LibTechContext context) : base(context)
        {
        }
    }
}
