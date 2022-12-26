using LibTech.SharedKernel;

namespace LibTech.Domain
{
    public class VendingMachine : AggregateRoot
    {
        public VendingMachine()
        {
            MoneyInside = Money.None;
            MoneyInTransaction = 0m;
        }

        public Money MoneyInside { get; set; }
        public decimal MoneyInTransaction { get; set; }
        public virtual IReadOnlyCollection<Slot> Slots { get; set; }

        public void InsertMoney(Money money)
        {
            Money[] coins = new Money[] { Money.Cent, Money.TenCent, Money.QuarterCent, Money.OneDollar, Money.FiveDollar, Money.TwentyDollar };
            if (!coins.Contains(money))
                throw new InvalidOperationException("Invalid currency inserted.");

            MoneyInTransaction += money.Amount;
            MoneyInside += money;
        }

        public string CanBuyBook(int position)
        {
            var bookPile = GetBookPile(position);

            if (bookPile.Quantity == 0)
                return "The book pile is empty.";

            if (MoneyInTransaction < bookPile.Price)
                return "Not enough money.";

            if (!MoneyInside.CanAllocate(MoneyInTransaction - bookPile.Price))
                return "not enough change";

            return string.Empty;
        }

        public void ReturnMoney()
        {
            Money moneyToReturn = MoneyInside.Allocate(MoneyInTransaction);
            MoneyInside -= moneyToReturn;
            MoneyInTransaction = 0m;
        }

        public void BuyBook(int position)
        {
            var slot = GetSlot(position);

            if (slot.BookPile.Price > MoneyInTransaction)
            {
                Money moneyToReturn = MoneyInside.Allocate(MoneyInTransaction);
                MoneyInTransaction = moneyToReturn.Amount;
                MoneyInside -= moneyToReturn;

                throw new InvalidOperationException("Book price is higher than amount inserted.");
            }

            Money change = MoneyInside.Allocate(MoneyInTransaction - slot.BookPile.Price);

            if (change.Amount < (MoneyInTransaction - slot.BookPile.Price))
            {
                Money moneyToReturn = MoneyInside.Allocate(MoneyInTransaction);
                MoneyInTransaction = moneyToReturn.Amount;
                MoneyInside -= moneyToReturn;

                throw new InvalidOperationException("No change available for this purchase value inserted.");
            }

            slot.BookPile = slot.BookPile.Subtract(1);

            MoneyInside -= change;
            MoneyInTransaction = 0m;
        }

        public void LoadBooks(int position, BookPile bookPile)
        {
            Slot slot = GetSlot(position);
            slot.BookPile = bookPile;
        }

        private Slot GetSlot(int position)
        {
            return Slots.Single(x => x.Position == position);
        }

        public BookPile GetBookPile(int position)
        {
            return GetSlot(position).BookPile;
        }

        public void LoadMoney(Money money)
        {
            MoneyInside += money;
        }
    }
}
