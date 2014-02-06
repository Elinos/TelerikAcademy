using System;

namespace FilesShelf.Models
{
    public static class Test
    {
        public static void Main()
        {
            //change directory details to test Tasks creation
            var collection = BookLibraryManager.GetBookPath(@"C:\Users\Vladislav Valentinov\Desktop\physics");

            var tasks = Task.CreateTasks(collection);

            var booklist = Task.ProcessTasks(tasks);

            foreach (var book in booklist)
            {
                Console.WriteLine(book);
            }
        }
    }
}
