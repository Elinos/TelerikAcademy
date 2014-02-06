using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Task5
    {
        static void Main(string[] args)
        {
            if (File.Exists(@"..\..\input.txt"))
                Console.SetIn(new StreamReader(@"..\..\input.txt"));
            string firstLine = Console.ReadLine();
            int k = int.Parse(Console.ReadLine());
            for (int i = 0; i < k; i++)
            {
                Console.ReadLine();
            }
            Console.WriteLine(k);
        }
    }
}
