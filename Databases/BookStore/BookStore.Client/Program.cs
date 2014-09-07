using System;
using System.Linq;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new BookStoreContext();
            var book = new Book
            {
                Title = "Test"
            };
            db.Books.Add(book);
            db.SaveChanges();
        }
    }
}
