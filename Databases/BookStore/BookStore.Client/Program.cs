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
            var xmlParser = new XmlParser(db);
            var booksToAdd = xmlParser.GetBooksFromXML();
            foreach (var book in booksToAdd)
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }
    }
}
