using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray64
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray64 test = new BitArray64(2000);
            BitArray64 test2 = new BitArray64(2000);
            Console.WriteLine(test == test2);

            foreach (int item in test)
            {
                Console.Write(item);
            }

            Console.WriteLine();
            Console.WriteLine(test[10]);
        }
    }
}
