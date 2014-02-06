using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilesShelf.Models;
using Task = FilesShelf.Models.Task;

namespace ModelsTest
{
    class Program
    {
        static void Main()
        {
            //change directory details to test Tasks creation
            var collection = BookLibraryManager.GetBookPath(@"C:\Users\Vladislav Valentinov\Desktop\Pdfs");

            var tasks = Task.CreateTasks(collection);

            var booklist = Task.ProcessTasks(tasks);

            foreach (var book in booklist)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}
