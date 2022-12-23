using LibTech.SharedKernel;

namespace LibTech.Domain
{
    public class Slot : Entity
    {
        public BookPile BookPile { get; set; }
        public VendingMachine VendingMachine { get; set; }
        public int Position { get; set; }

        private Slot() { }

        public Slot(VendingMachine vendingMachine, int position) : this()
        {
            VendingMachine = vendingMachine;
            Position = position;
            BookPile = new BookPile(null, 0, 0m);
        }
    }
}
