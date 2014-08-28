using System;
using System.Linq;

namespace TaskThree
{
    class TaskThree
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tree is building, please wait for few seconds...");
            DirectoryTree dirTree = new DirectoryTree(@"C:\Windows");

            Console.WriteLine("Done.");

            Console.WriteLine("\nTree size: ");
            double sizeInMB = dirTree.CalculateSizeOfTree();
            Console.WriteLine("{0} megabytes", sizeInMB);
            Console.WriteLine("{0} or gigabytes", sizeInMB / 1024);

            Console.WriteLine("\nCalculate size of tree folder and subfolders: ");
            sizeInMB = dirTree.CalculateSizeOfFolder("Cursors");
            Console.WriteLine("{0} megabytes", sizeInMB);
            Console.WriteLine("{0} or gigabytes", sizeInMB / 1024);
        }
    }
}
