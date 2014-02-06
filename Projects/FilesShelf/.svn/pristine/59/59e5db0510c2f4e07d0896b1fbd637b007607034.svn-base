using System;
using System.Collections.Generic;
using System.Linq;
using FilesShelf.SQLite;
using System.Data;

namespace FilesShelf.Models
{
    public class Task
    {
        public string PathName { get; set; }
        public State CurrentState { get; set; }
        public string ID { get; set; }
        public string ISBN { get; set; }        

        public static IEnumerable<Task> CreateTasks(IEnumerable<string> pathNames)
        {
            return pathNames.Select(pathName => new Task {PathName = pathName, CurrentState = State.Waiting}).ToList();
        }

        public static IEnumerable<Book> ProcessTasks(IEnumerable<Task> tasks)
        {
            var bookList = new List<Book>();

            foreach (var task in tasks)
            {
                task.CurrentState = State.InProgress;
                var book = new Book { PathName = task.PathName };
                var parsedText = BookLibraryManager.ParseUsingPdfBox(book.PathName);

                if (parsedText == null)
                {
                    task.CurrentState = State.Failed;
                }
                else
                {
                    var processedIsbn = BookLibraryManager.GetIsbn(parsedText);

                    if (processedIsbn != null)
                    {
                        book.Isbn = processedIsbn;
                        BooksLibrary.CreateBook(book);
                        task.CurrentState = book.Title != null ? State.Completed : State.Failed;
                    }
                    else
                    {
                        task.CurrentState = State.Failed;
                    }
                }

                bookList.Add(book);
                //Uncomment if you want to see task state
                //Console.WriteLine(task.CurrentState);

            }

            return bookList;
        }
    }
}
