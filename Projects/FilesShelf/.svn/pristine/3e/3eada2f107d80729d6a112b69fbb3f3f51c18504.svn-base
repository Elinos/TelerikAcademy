using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesShelf.SQLite;
using System.Data;

namespace FilesShelf.Models.Database
{
    public class DbBook : FilesShelfDbObject
    {

        public static void Insert(string bookTitle, SQLiteDatabase db)
        {
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                string[] splitedFileName=bookTitle.Split(new string[]{"\\"},StringSplitOptions.RemoveEmptyEntries);
                data.Add("Title",splitedFileName[splitedFileName.Length-1]);
                data.Add("FilePath", bookTitle);
                bool succ = db.Insert("Books", data);
                if (!succ)
                {
                    return;
                    //throw new Exception();
                }
            }
            catch
            {
                throw new FSSQLiteException("An unexpected error occured when trying to insert a new book.");
            }
        }


        public static void Insert(Book bookToInsert, SQLiteDatabase db)
        {
            try
            {
                Dictionary<string, string> data = BookToFieldsDictionary(bookToInsert);
                bool succ = db.Insert("Books", data);
                if (!succ)
                {
                    return;
                    //throw new Exception();
                }
            }
            catch
            {
                throw new FSSQLiteException("An unexpected error occured when trying to insert a new book.");
            }
        }

        private static IList<Person> GetAuthorsFromString(string authorsString)
        {
            IList<Person> authors = new List<Person>();
            string[] authorsStr = authorsString.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string authorStr in authorsStr)
            {
                authors.Add(new Person() { FullName = authorStr.Trim() });
            }
            return authors;
        }


        private static IList<Genre> GetGenresFromString(string genresString)
        {
            IList<Genre> genres = new List<Genre>();
            string[] genresStr = genresString.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string genreStr in genresStr)
            {
                genres.Add(new Genre() { Name = genreStr.Trim() });
            }
            return genres;
        }

        private static Dictionary<string, string> BookToFieldsDictionary(Book bookToInsert)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            if (bookToInsert.Title != null)
            {
                data.Add("Title", SQLiteDatabase.EscapeSpecialChars(bookToInsert.Title));
            }
            if (bookToInsert.Isbn != null)
            {
                data.Add("ISBN", bookToInsert.Isbn);
            }
            if (bookToInsert.Authors != null)
            {
                data.Add("Authors", DbCommon.ConvertListOfObjectsToString(bookToInsert.Authors.ToArray()));
            }
            if (bookToInsert.Genres != null)
            {
                data.Add("Genres", DbCommon.ConvertListOfObjectsToString(bookToInsert.Genres.ToArray()));
            }
            if (bookToInsert.Description != null)
            {
                data.Add("Description", SQLiteDatabase.EscapeSpecialChars(bookToInsert.Description));
            }
            if (bookToInsert.Publisher != null)
            {
                data.Add("Publisher", SQLiteDatabase.EscapeSpecialChars(bookToInsert.Publisher));
            }
            if (bookToInsert.SiteRating != null)
            {
                data.Add("SiteRating", bookToInsert.SiteRating.ToString());
            }
            if (bookToInsert.UserRating != null)
            {
                data.Add("UserRating", bookToInsert.UserRating.ToString());
            }
            if (bookToInsert.PublicationDate != null)
            {
                data.Add("PublicationDate", SQLiteDatabase.EscapeSpecialChars(bookToInsert.PublicationDate.ToString()));
            }
            if (bookToInsert.NumberOfPages != null)
            {
                data.Add("Pages", bookToInsert.NumberOfPages.ToString());
            }
            if (bookToInsert.Cover != null)
            {
                data.Add("CoverImage", bookToInsert.Cover.ToString());
            }
            if (bookToInsert.PathName != null)
            {
                data.Add("FilePath", bookToInsert.PathName.ToString());
            }
            return data;
        }

        public static void Update(string id, Book newData, SQLiteDatabase db)
        {
            try
            {
                Dictionary<string, string> data = BookToFieldsDictionary(newData);
                bool succ = db.Update("Books", data, String.Format("id={0}", id));
                if (!succ)
                {
                    throw new Exception();
                }
            }
            catch
            {
                throw new FSSQLiteException("An unexpected error occured when trying to update a book.");
            }
        }

        public static void Update(string id, string columnId, string newValue, SQLiteDatabase db)
        {
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add(columnId, newValue);
                bool succ = db.Update("Books", data, String.Format("id={0}", id));
                if (!succ)
                {
                    throw new Exception();
                }
            }
            catch
            {
                throw new FSSQLiteException("An unexpected error occured when trying to update a book.");
            }
        }

        public static void Delete(string id, SQLiteDatabase db)
        {
            try
            {
                bool succ = db.Delete("Books", String.Format("id={0}", id));
                if (!succ)
                {
                    throw new Exception();
                }
            }
            catch
            {
                throw new FSSQLiteException("An unexpected error occured when trying to delete a book.");
            }
        }

        public static List<Book> Select(string condition, SQLiteDatabase db)
        {
            try
            {
                List<Book> books = new List<Book>();
                DataTable resultSet = db.GetDataTable(String.Format("SELECT * FROM 'Books' {0}", condition));
                foreach (DataRow row in resultSet.Rows)
                {
                    Book book = new Book();
                    book.ID = row["id"].ToString();
                    book.Title = row["Title"].ToString();
                    book.Isbn = row["ISBN"].ToString();
                    book.Authors = GetAuthorsFromString(row["Authors"].ToString());
                    book.Genres = GetGenresFromString(row["Genres"].ToString());
                    book.Description = row["Description"].ToString();
                    book.PathName = row["FilePath"].ToString();
                    book.Publisher = row["Publisher"].ToString();
                    int siteRating = 0;
                    bool succParsingSite = int.TryParse(row["SiteRating"].ToString(), out siteRating);
                    book.SiteRating = siteRating;
                    int userRating = 0;
                    bool succParsingUser = int.TryParse(row["UserRating"].ToString(), out userRating);
                    book.UserRating = userRating;
                    DateTime publicationDate = DateTime.MinValue;
                    bool succParsingDateTime = DateTime.TryParse(row["PublicationDate"].ToString(), out publicationDate);
                    book.PublicationDate = publicationDate;
                    ulong numOfPages = 0;
                    bool succParsingNumOfPages = ulong.TryParse(row["Pages"].ToString(), out numOfPages);
                    book.NumberOfPages = numOfPages;
                    book.Cover = row["CoverImage"].ToString();
                    /*string taskStatus = row["taskStatus"].ToString();
                    switch (int.Parse(taskStatus))
                    {
                        case 1:
                            tsk.CurrentState = State.InProgress;
                            break;
                        case 2:
                            tsk.CurrentState = State.Failed;
                            break;
                        case 3:
                            tsk.CurrentState = State.Completed;
                            break;
                        default:
                            tsk.CurrentState = State.Waiting;
                            break;
                    }*/
                    books.Add(book);
                }
                return books;
            }
            catch (Exception fail)
            {
                throw new FSSQLiteException("An error occurred when trying to select a book.");
            }
        }
    }
}
