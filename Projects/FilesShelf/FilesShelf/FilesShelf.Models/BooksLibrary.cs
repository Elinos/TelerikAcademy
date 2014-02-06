using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using FilesShelf.SQLite;
using System.Data;
using System.Globalization;

namespace FilesShelf.Models
{
    public class BooksLibrary : MediaLibrary
    {
        public List<Book> MediaList = new List<Book>();

        /// <summary>
        /// Insert a book in DB
        /// </summary>
        /// <param name="bookToInsert"></param>
        /// <param name="db"></param>
        public static void InsertBook(Book bookToInsert, SQLiteDatabase db)
        {
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();

                data.Add("title", SQLiteDatabase.EscapeSpecialChars(bookToInsert.Title));
                data.Add("isbn", SQLiteDatabase.EscapeSpecialChars(bookToInsert.Isbn));
                data.Add("publisher", SQLiteDatabase.EscapeSpecialChars(bookToInsert.Publisher));
                data.Add("userRating", bookToInsert.UserRating.ToString());
                data.Add("LibraryThingRating", bookToInsert.SiteRating.ToString());
                data.Add("datePublication", bookToInsert.PublicationDate.ToString());
                string genresString = "";                
                foreach (Genre genre in bookToInsert.Genres)
                {
                    genresString+=genre.ToString()+"";
                }
                data.Add("genres", genresString);
                data.Add("description", SQLiteDatabase.EscapeSpecialChars(bookToInsert.Description));
                data.Add("pages", bookToInsert.NumberOfPages.ToString());
                db.Insert("Books", data);                
                


                /*foreach (var genre in bookToInsert.Genres)
                {                    
                    DataTable genreIds = db.GetIdByItem("Genres", genre.Name);
                    foreach (DataRow g in genreIds.Rows)
                    {
                        data.Add("genres", g["id"].ToString());
                    }
                }

                foreach (var author in bookToInsert.Authors)
                {
                    DataTable authorIds = db.GetIdByItem("Genres", author.FullName);
                    foreach (DataRow a in authorIds.Rows)
                    {
                        data.Add("authors", a["id"].ToString());
                    }
                }*/
            }
            catch (Exception fail)
            {
                throw new FSSQLiteException("An error occurred when trying to insert a new book.");
            }
        }

        /// <summary>
        /// Insert a book only with a title
        /// </summary>
        /// <param name="title"></param>
        /// <param name="db"></param>
        public static void InsertBook(string title, SQLiteDatabase db)
        {
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add("title", SQLiteDatabase.EscapeSpecialChars(title));
                db.Insert("Books", data);
            }
            catch (Exception fail)
            {
                throw new FSSQLiteException("An error occurred when trying to insert a new book.");
            }
        }

        /// <summary>
        /// Get all books from DB and insert them in a List
        /// </summary>
        public override void CreateMediaLibrary()
        {
            SQLiteDatabase database = new SQLiteDatabase();
            string query = "SELECT * FROM Books";
            DataTable books = database.GetDataTable(query);

            foreach (DataRow b in books.Rows)
            {
                Book book = new Book();
                book.Isbn = b["isbn"].ToString();
                book.Title = b["title"].ToString();
                book.Publisher = b["publisher"].ToString();
                //book.SiteRating = (decimal?)b["rating"]??0;
                book.SiteRating = 0;
                //book.UserRating = (decimal?)b["userRating"];
                book.UserRating = 0;
                //book.PublicationDate = (DateTime?)b["datePublication"] ?? DateTime.MinValue;
                int genreId = int.Parse(b["genres"].ToString());
                DataTable genresTable = database.GetItemById("Genres", genreId);
                foreach (DataRow genre in genresTable.Rows)
                {
                    book.Genres.Add(new Genre { Name = genre.ToString() });
                }

                //book.NumberOfPages = ulong.Parse(b["pages"].ToString());
                book.NumberOfPages = 0;
                book.Description = b["description"].ToString();
                this.MediaList.Add(book);
            }

            //throw new NotImplementedException();
        }

        //this method creates a new instance of the book class by given ISBN
        public static void CreateBook(Book book)
        {

            var apis = new Action<Book>[]
            {
                ExtendUsingOpenLibrary,
                ExtendUsingLibraryThing,
                ExtendUsingBookShare,
            };

            foreach (var action in apis)
            {
                try
                {
                    action(book);
                }
                catch (WebException) { }
            }
        }


        //OpenLibrary API request get info method
        private static void ExtendUsingOpenLibrary(Book book)
        {
            var response =
                GetApiResponse(string.Format("http://openlibrary.org/api/volumes/brief/isbn/{0}.json", book.Isbn));

            if (response == "[]")
            {
                return;
            }

            response = Regex.Replace(response, "{\"records\": {\"/books/OL\\d+M\"", "{\"records\": {\"book\"");

            dynamic parsed = JsonConvert.DeserializeObject(response);

            var root = parsed.records.book;

            var newBook = new Book();

            try { newBook.Title = root.details.details.title; }
            catch (RuntimeBinderException) { }
            try { newBook.PublicationDate = new DateTime(root.details.details.publish_date, 0, 0); }
            catch (RuntimeBinderException) { }
            try { newBook.NumberOfPages = root.details.details.number_of_pages; }
            catch (RuntimeBinderException) { }
            try { newBook.Cover = root.data.cover.large; }
            catch (RuntimeBinderException) { }
            try { newBook.Thumbnail = root.data.cover.small; }
            catch (RuntimeBinderException) { }
            try { newBook.Publisher = root.details.details.publishers[0]; }
            catch (RuntimeBinderException) { }
            try { newBook.Description = root.details.details.description.value; }
            catch (RuntimeBinderException) { }

            try
            {
                foreach (var author in root.details.details.authors)
                {
                    newBook.Authors.Add(new Person { FullName = author.name });
                }
            }
            catch (RuntimeBinderException) { }
            catch (NullReferenceException) { }

            try
            {
                foreach (var subject in root.details.details.subjects)
                {
                    newBook.Genres.Add(new Genre { Name = subject });
                }
            }
            catch (RuntimeBinderException) { }
            catch (NullReferenceException) { }

            Merge(book, newBook);
        }

        //LibraryThing API request get info method
        private static void ExtendUsingLibraryThing(Book book)
        {
            var response = GetApiResponse(string.Format("http://www.librarything.com/services/rest/1.1/?method=librarything.ck.getwork&isbn={0}&apikey=afe5ff912a026dd47575aa5049c62a32", book.Isbn));
            if(response==null)
            {
                return;
            }

            var result = XDocument.Parse(response);
            

            if (result.Element("response").Attribute("stat").Value != "ok")
            {
                return;
            }

            XNamespace xNamespace = "http://www.librarything.com/";
            var root = result.Element("response").Element(xNamespace + "ltml").Element(xNamespace + "item");
            var authorName = root.Element(xNamespace + "author").Value;
            var apiRating = root.Element(xNamespace + "rating").Value;
            var title = root.Element(xNamespace + "title").Value;

            var newBook = new Book { Title = title, Authors = { new Person { FullName = authorName } }, SiteRating = decimal.Parse(apiRating, CultureInfo.InvariantCulture) };

            Merge(book, newBook);
        }

        //BookShare API request get info method
        private static void ExtendUsingBookShare(Book book)
        {
            var response = GetApiResponse(string.Format("https://api.bookshare.org/book/isbn/{0}/format/xml?api_key=vbr8wzh6tpxvxr3xzy577scc", book.Isbn));

            if (response.Contains("Invalid/Incorrect ISBN number"))
            {
                return;
            }
            if (response.Contains("Book not found"))
            {
                return;
            }
            if (response.Contains("Invalid/Incomplete Request"))
            {
                return;
            }

            //TODO: Catch all null reference exceptions

            var result = XDocument.Parse(response);

            var root = result.Element("bookshare").Element("book").Element("metadata");
            var title = root.Element("title").Value;
            var authorName = root.Element("author").Value;
            var description = root.Element("brief-synopsis").Value;
            var genres = root.Elements("category");
            var publisher = root.Element("publisher").Value;
            //var publicationDate = DateTime.ParseExact(root.Element("publish-date").Value, "ddmmyyyy", new CultureInfo("bg-BG"));
            var newBook = new Book { Title = title, Authors = { new Person { FullName = authorName } }, Description = description, Publisher = publisher };

            foreach (var genre in genres)
            {
                newBook.Genres.Add(new Genre { Name = genre.Value });
            }

            Merge(book, newBook);
        }

        public void RemoveBook()
        {
            throw new System.NotImplementedException();
        }

    }
}

