using LibTech.Domain.SeedWork;

namespace LibTech.Domain
{
    public class VendingMachine : Entity
    {
        private readonly IVendingMachineRepository _repository;
        public VendingMachine(IVendingMachineRepository repository)
        {
            _repository = repository;
        }

        private VendingMachine() { }

        public Money MoneyInside { get; set; } = Money.None;
        public Money MoneyInTransaction { get; set; } = Money.None;

        public async Task InsertMoney(Money money)
        {
            Money[] coins = new Money[] { Money.Cent, Money.TenCent, Money.QuarterCent, Money.OneDollar, Money.FiveDollar, Money.TwentyDollar };
            if (!coins.Contains(money))
                throw new InvalidOperationException();

            MoneyInTransaction += money;
            MoneyInside += money;

            await _repository.AddAsync(this);
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
