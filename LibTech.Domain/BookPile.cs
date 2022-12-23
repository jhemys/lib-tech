namespace LibTech.Domain
{
    public sealed class BookPile : ValueObject<BookPile>
    {
        public static readonly BookPile Empty = new BookPile(Book.Empty, 0, 0m);
        public Book Book { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        private BookPile() { }

        public BookPile(Book book, int quantity, decimal price):  this()
        {
            if (quantity < 0)
                throw new InvalidOperationException("Invalid Quantity.");

            if (price < 0 || (price % 0.01m > 0))
                throw new InvalidOperationException("Invalid Price.");

            Book = book;
            Quantity = quantity;
            Price = price;
        }

        protected override bool EqualsCore(BookPile other)
        {
            return Book == other.Book 
                && Quantity == other.Quantity
                && Price == other.Price;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Book.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity;
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                return hashCode;
            }
        }

        public BookPile Subtract(int value)
        {
            return new BookPile(Book, Quantity - value, Price);
        }
    }
}
