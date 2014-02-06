using System;
using System.Collections.Generic;
using System.Linq;

namespace FilesShelf.Models
{
    public class Book : Media
    {
        public string ID { get; set; }
        
        public string Isbn { get; set; }

        public IList<Person> Authors { get; set; }

        public ulong NumberOfPages { get; set; }

        public decimal? SiteRating { get; set; }       

        public string Publisher { get; set; }

        public BookType Type { get; set; }

        public Book ()
            : base()
        {
            this.Authors = new List<Person>();
        }

        public Book(string isbn, string coverUrl, IList<Person> authors, ulong numberOfPages, decimal? siteRating, string title, decimal? userRating, DateTime? publicationDate, string description,string publisher)
            : base(title, coverUrl, userRating, publicationDate, description)
        {
            this.Isbn = isbn;
            this.Authors = authors;
            this.NumberOfPages = numberOfPages;
            this.SiteRating = siteRating;
            this.Publisher = publisher;
            //this.Authors = new List<Person>();
        }

        public override string ToString()
        {
            var info = new List<string>();

            info.Add("Title: " + this.Title);
            info.Add("Authors: " + string.Concat(this.Authors.Select(x => Environment.NewLine + "  " + x)));
            info.Add("ISBN: " + this.Isbn);
            info.Add("Publisher: " + this.Publisher);
            var publicationDate = this.PublicationDate;
            if (publicationDate != null)
                info.Add("Publish date: " + publicationDate.Value.ToString("dd MMMM yyyy"));
            info.Add("Site Rating: " + this.SiteRating.GetValueOrDefault());
            info.Add("Number of pages: " + this.NumberOfPages);
            info.Add("Cover url: " + this.Cover);
            info.Add("Thumbnail url: " + this.Thumbnail);
            info.Add("Genres: " + string.Concat(this.Genres.Select(x => Environment.NewLine + "  " + x)));
            info.Add("Description: " + this.Description);

            return string.Join(Environment.NewLine, info);
        }

    }

}