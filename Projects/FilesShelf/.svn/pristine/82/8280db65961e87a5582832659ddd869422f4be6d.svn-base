using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesShelf.SQLite;
using FilesShelf.Models.Database;

namespace FilesShelf.Models
{
    public class QueryManager
    {
        #region Fields and Properties

        private QueryRequest request;
        public SQLiteDatabase db { get; set; }

        public QueryRequest Request
        {
            get
            {
                return this.request;
            }
            set
            {
                if (value != null)
                {
                    this.request = value;
                    GenerateResponse();
                }
            }
        }

        public Dictionary<string, List<Book>> Response { private set; get; }

        #endregion

        #region Methods

        //default constructor
        public QueryManager()
        {
            //this.Request = new QueryRequest("", GroupByType.ByTitleStartingLetter);
        }

        public void GenerateResponse()
        {

            Dictionary<string, List<Book>> response = new Dictionary<string, List<Book>>();
            List<Book> allBooks = DbBook.Select(string.Format("WHERE Title LIKE '%{0}%'",this.request.SearchTerm), db);
            if (request.GroupingType == GroupByType.ByTitleStartingLetter)
            {
                foreach (var book in allBooks)
                {
                    if (response.ContainsKey(book.Title[0].ToString()))
                    {
                        response[book.Title[0].ToString()].Add(book);
                    }
                    else
                    {
                        response[book.Title[0].ToString()] = new List<Book>();
                        response[book.Title[0].ToString()].Add(book);
                    }
                }
            }
            else if (request.GroupingType == GroupByType.ByAuthor)
            {
                foreach (var book in allBooks)
                {
                    foreach (var author in book.Authors)
                    {
                        if (response.ContainsKey(author.FullName))
                        {
                            response[author.FullName].Add(book);
                        }
                        else
                        {
                            response[author.FullName] = new List<Book>();
                            response[author.FullName].Add(book);
                        }
                    }
                }
            }
            else
            {
                foreach (var book in allBooks)
                {
                    foreach (var genre in book.Genres)
                    {
                        if (response.ContainsKey(genre.Name))
                        {
                            response[genre.Name].Add(book);
                        }
                        else
                        {
                            response[genre.Name] = new List<Book>();
                            response[genre.Name].Add(book);
                        }
                    }
                }
            }
            this.Response = response;
        }

        public List<Book> GenerateGroupSpecificResponse(string groupName)
        {
            List<Book> response = new List<Book>();
            return response;
        }

        #endregion
    }
}
