using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesShelf.Models;
using FilesShelf.SQLite;
using dbObjects = FilesShelf.Models.Database;

namespace QueryManagerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteDatabase database = new SQLiteDatabase("MediaLibrary.sqlite");
            QueryManager queriesManager = new QueryManager();
            queriesManager.db = database;
            //set a new requets
            queriesManager.Request = new QueryRequest("q", GroupByType.ByTitleStartingLetter);
            //List<Book> books = dbObjects.DbBook.Select("",database);
            Dictionary<string, List<Book>> querieResults = queriesManager.Response;
        }
    }
}
