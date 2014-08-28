using System;
using System.IO;
using System.Linq;

namespace TaskTwo
{
    class TaskTwo
    {
        static void Main(string[] args)
        {
            DirSearch(@"C:\Windows");
        }
        static void DirSearch(string dir)
        {
            try
            {
                foreach (string f in Directory.GetFiles(dir))
                {
                    if (f.EndsWith(".exe"))
                    {
                        Console.WriteLine(Path.GetFileName(f));                    
                    }
                }
                foreach (string d in Directory.GetDirectories(dir))
                {
                    DirSearch(d);
                }

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
