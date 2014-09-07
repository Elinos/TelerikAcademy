using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.XMLParser
{
    public class XmlParser
    {
        private string XmlFilePath;
        private BookStoreContext db;
        public XmlParser(BookStoreContext db, string xmlFilePath)
        {
            this.XmlFilePath = xmlFilePath;
            this.db = db;
        }

        public void GenerateQueryResults()
        {
            XElement xmlFile = XElement.Load(XmlFilePath);
            var queriesAsXML = xmlFile.Elements();
            var reviewResultsXML = new XElement("search-results");
            GenerateXMLResults(queriesAsXML, reviewResultsXML);
        }
 
        private void GenerateXMLResults(IEnumerable<XElement> queriesAsXML, XElement reviewResultsXML)
        {
            foreach (var xmlQuery in queriesAsXML)
            {
                var queryInReviews = db.Reviews.AsQueryable();

                if (xmlQuery.Attribute("type").Value == "by-period")
                {
                    var startDate = DateTime.Parse(xmlQuery.Element("start-date").Value);
                    var endDate = DateTime.Parse(xmlQuery.Element("end-date").Value);
                    queryInReviews = queryInReviews.Where(r => startDate <= r.CreationDate && r.CreationDate <= endDate);
                }
                else if (xmlQuery.Attribute("type").Value == "by-author")
                {
                    var authorName = xmlQuery.Element("author-name").Value;
                    queryInReviews = queryInReviews.Where(r => r.Author.Name == authorName);
                }

                queryInReviews = queryInReviews.OrderBy(r => r.CreationDate).ThenBy(r => r.Text);
                var resultSet = queryInReviews.Select(r => new
                {
                    Date = r.CreationDate,
                    Content = r.Text,
                    Book = new
                    {
                        Title = r.Book.Title,
                        Authors = r.Book.Authors.OrderBy(a => a.Name).Select(a => a.Name),
                        ISBN = r.Book.ISBN,
                        URL = r.Book.WebSite
                    }
                }).ToList();
                var resultSetXML = new XElement("result-set");

                foreach (var review in resultSet)
                {
                    var reviewXML = new XElement("review");
                    reviewXML.Add(new XElement("date", review.Date.ToString("d-MMM-yyyy", CultureInfo.InstalledUICulture)));
                    reviewXML.Add(new XElement("content", review.Content));
                    var bookXML = new XElement("book");
                    bookXML.Add(new XElement("title", review.Book.Title));
                    if (review.Book.Authors.Count() != 0)
                    {
                        bookXML.Add(new XElement("authors", String.Join(", ", review.Book.Authors)));
                    }
                    if (review.Book.ISBN != null)
                    {
                        bookXML.Add(new XElement("isbn", review.Book.ISBN));
                    }
                    if (review.Book.URL != null)
                    {
                        bookXML.Add(new XElement("url", review.Book.URL));
                    }
                    reviewXML.Add(bookXML);
                    resultSetXML.Add(reviewXML);
                }
                reviewResultsXML.Add(resultSetXML);
            }
            reviewResultsXML.Save(@"..\..\..\reviews-search-results.xml");
        }

        public List<Book> GetBooksFromXML()
        {
            var books = new List<Book>();
            XElement xmlFile = XElement.Load(XmlFilePath);
            var booksAsXML = xmlFile.Elements();

            ExtractBooksFromXML(booksAsXML, books);
            return books;
        }

        private void ExtractBooksFromXML(IEnumerable<XElement> booksAsXML, List<Book> books)
        {
            foreach (var bookAsXML in booksAsXML)
            {
                var currentBook = new Book();
                currentBook.Title = bookAsXML.Element("title").Value;
                var xmlISBN = bookAsXML.Element("isbn");
                if (xmlISBN != null)
                {
                    var booksExist = db.Books.Any(b => b.ISBN == xmlISBN.Value);
                    if (booksExist)
                    {
                        throw new ArgumentException("The ISBN number is not unique!");
                    }
                    currentBook.ISBN = xmlISBN.Value;
                }
                var xmlWebSite = bookAsXML.Element("web-site");
                if (xmlWebSite != null)
                {
                    currentBook.WebSite = xmlWebSite.Value;
                }
                var xmlPrice = bookAsXML.Element("price");
                if (xmlPrice != null)
                {
                    currentBook.Price = decimal.Parse(xmlPrice.Value, CultureInfo.InvariantCulture);
                }
                var xmlAuthors = bookAsXML.Element("authors");
                if (xmlAuthors != null)
                {
                    foreach (var xmlAuthor in xmlAuthors.Elements("author"))
                    {
                        var authorName = xmlAuthor.Value;
                        var author = GetAuthor(authorName);
                        currentBook.Authors.Add(author);
                    }
                }

                var xmlReviews = bookAsXML.Element("reviews");
                if (xmlReviews != null)
                {
                    foreach (var xmlReview in xmlReviews.Elements("review"))
                    {
                        var reviewDate = xmlReview.Attribute("date");
                        var authorName = xmlReview.Attribute("author");
                        var review = new Review
                        {
                            Text = xmlReview.Value,
                            CreationDate = reviewDate == null ? DateTime.Now : DateTime.Parse(reviewDate.Value),
                            Author = authorName == null ? null : GetAuthor(authorName.Value)
                        };
                        currentBook.Reviews.Add(review);
                    }
                }
                books.Add(currentBook);
            }
        }

        private Author GetAuthor(string authorName)
        {
            var author = db.Authors.FirstOrDefault(a => a.Name == authorName);
            if (author == null)
            {
                author = new Author
                {
                    Name = authorName
                };
            }
            return author;
        }
    }
}
