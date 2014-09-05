using System;
using System.Linq;

namespace _05.VariationsWithRepetition
{
    class VariationsWithRepetitions
    {

        const int n = 3;
        const int k = 2;
        static string[] objects = new string[n] { "hi", "a", "b" };
        static int[] arr = new int[k];

        static void Main()
        {
            GenerateVariationsWithRepetitions(0);
        }

        static void GenerateVariationsWithRepetitions(int index)
        {
            if (index >= k)
            {
                PrintVariations();
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    arr[index] = i;
                    GenerateVariationsWithRepetitions(index + 1);
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
