using LibTech.Domain.SeedWork;

namespace LibTech.Domain
{
    public class VendingMachine : Entity
    {
        //public VendingMachine(LibTech.Infrastructure.Data.LibTechContext context)
        //{

        //}
        public Money MoneyInside { get; set; } = Money.None;
        public Money MoneyInTransaction { get; set; } = Money.None;

        public void InsertMoney(Money money)
        {
            Money[] coins = new Money[] { Money.Cent, Money.TenCent, Money.QuarterCent, Money.OneDollar, Money.FiveDollar, Money.TwentyDollar };
            if (!coins.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            MoneyInTransaction = Money.None;
        }

        public void BuyBook()
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = Money.None;
        }
    }
}
