using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CombinationsNoRep
{
    class CombinationsNoRep
    {
        const int n = 3;
        const int k = 2;
        static string[] objects = new string[n] { "test", "rock", "fun" };
        static int[] arr = new int[k];

        static void Main()
        {
            GenerateCombinationsNoRepetitions(0, 0);
        }

        static void GenerateCombinationsNoRepetitions(int index, int start)
        {
            if (index >= k)
            {
                PrintVariations();
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    arr[index] = i;
                    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                }
            }
        }

        static void PrintVariations()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(objects[arr[i]] + " ");
            }
            Console.WriteLine();
        }
    }
}
