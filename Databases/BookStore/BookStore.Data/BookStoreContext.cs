using System;
using System.Data.Entity;
using System.Linq;
using BookStore.Models;
using BookStore.Data.Migrations;

namespace BookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext()
            : base("BookStoreDatabase")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreContext, Configuration>());
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Review> Reviews { get; set; }
    }
}
