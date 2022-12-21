using FluentAssertions;
using LibTech.Domain;

namespace LibTech.Tests
{
    public class BookPileSpecs
    {
        [Fact]
        public void Create_valid_BookPile()
        {
            var bookPile = new BookPile(new Book("Test"), 1, 1);
            Assert.NotNull(bookPile);
        }

        [Fact]
        public void Throws_error_for_invalid_quantity()
        {
            Action action = () => new BookPile(new Book("Test"), -1, 1);
            action.Should().Throw<InvalidOperationException>().Which.Message.Should().Be("Invalid Quantity.");
        }

        [Fact]
        public void Throws_error_for_invalid_price()
        {
            Action action = () => new BookPile(new Book("Test"), 1, -1);
            action.Should().Throw<InvalidOperationException>().Which.Message.Should().Be("Invalid Price.");
        }
    }
}
