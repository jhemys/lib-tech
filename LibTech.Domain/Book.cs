using LibTech.SharedKernel;

namespace LibTech.Domain
{
    public class Book : AggregateRoot
    {
        public Book(string title, string author, string iSBN, string publisher, string description, string imageUrl, string url, string category, string subCategory, string language, string format, int pages)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            Publisher = publisher;
            Description = description;
            ImageUrl = imageUrl;
            Url = url;
            Category = category;
            SubCategory = subCategory;
            Language = language;
            Format = format;
            Pages = pages;
        }

        public Book(string title)
        {
            Title = title;
        }

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
    }
}