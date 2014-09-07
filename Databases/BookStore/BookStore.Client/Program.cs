using System;
using System.Linq;
using BookStore.Data;
using BookStore.XMLParser;

namespace BookStore.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new BookStoreContext();
            var booksParser = new XmlParser(db, @"..\..\..\complex-books.xml");
            var booksToAdd = booksParser.GetBooksFromXML();
            foreach (var book in booksToAdd)
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
            var queriesParser = new XmlParser(db, @"..\..\..\reviews-queries.xml");
            queriesParser.GenerateQueryResults();
        }
    }
}
