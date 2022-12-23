using FakeItEasy;
using FluentAssertions;
using LibTech.Domain;

namespace LibTech.Tests
{
    public class VendingMachineSpecs
    {
        [Fact]
        public async Task BuyBook_trades_inserted_money_for_a_book()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.LoadBooks(1, new BookPile(new Book("title"), 10, 1m));
            await vendingMachine.InsertMoney(Money.OneDollar);

            vendingMachine.BuyBook(1);

            vendingMachine.MoneyInTransaction.Should().Be(0m);
            vendingMachine.MoneyInside.Amount.Should().Be(1m);
            vendingMachine.GetBookPile(1).Quantity.Should().Be(9);
        }

        [Fact]
        public void Cannot_make_purchase_when_there_is_no_books()
        {
            var vendingMachine = new VendingMachine();

            Action action = () => vendingMachine.BuyBook(1);

            action.Should().Throw<InvalidOperationException>().Which.Message.Should().Be("Book price is higher than amount inserted.");
        }

        [Fact]
        public void Vending_machine_returns_money_with_highest_denomination_first()
        {
            var vendingMachine = new VendingMachine();

            vendingMachine.LoadMoney(Money.OneDollar);

            _ = vendingMachine.InsertMoney(Money.QuarterCent);
            _ = vendingMachine.InsertMoney(Money.QuarterCent);
            _ = vendingMachine.InsertMoney(Money.QuarterCent);
            _ = vendingMachine.InsertMoney(Money.QuarterCent);

            vendingMachine.ReturnMoney();

            vendingMachine.MoneyInside.QuarterCount.Should().Be(4);
            vendingMachine.MoneyInside.OneDollarCount.Should().Be(0);
        }

        [Fact]
        public async Task After_purchase_change_is_returned()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.LoadBooks(1, new BookPile(new Book("title"), 10, 0.5m));
            vendingMachine.LoadMoney(Money.TenCent * 10);

            await vendingMachine.InsertMoney(Money.OneDollar);
            vendingMachine.BuyBook(1);

            vendingMachine.MoneyInside.Amount.Should().Be(1.5m);
            vendingMachine.MoneyInTransaction.Should().Be(0m);
        }

        [Fact]
        public async Task Cannot_buy_book_if_not_enough_change()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.LoadBooks(1, new BookPile(new Book("title"), 10, 0.5m));
            vendingMachine.LoadMoney(Money.OneDollar);

            await vendingMachine.InsertMoney(Money.OneDollar);
            Action action = () => vendingMachine.BuyBook(1);

            action.Should().Throw<InvalidOperationException>().Which.Message.Should().Be("No change available for this purchase value inserted.");

            vendingMachine.GetBookPile(1).Quantity.Should().Be(10);
            vendingMachine.MoneyInside.Amount.Should().Be(1m);
            vendingMachine.MoneyInTransaction.Should().Be(1m);
        }
    }
}
