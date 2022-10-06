namespace LibTech.Domain
{
    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public string Publisher { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public string Url { get; private set; }
        public string Category { get; private set; }
        public string SubCategory { get; private set; }
        public string Language { get; private set; }
        public string Format { get; private set; }
        public int Pages { get; private set; }
        public double Price { get; private set; }
    }
}