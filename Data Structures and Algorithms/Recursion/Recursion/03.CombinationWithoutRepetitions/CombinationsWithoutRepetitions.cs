using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CombinationWithoutRepetitions
{
    class CombinationsWithoutRepetitions
    {
        const int n = 4;
        const int k = 2;
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
                    arr[index] = i + 1;
                    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                }
            }
        }

        static void PrintVariations()
        {
            Console.WriteLine(String.Join("", arr));
        }
    }
}
