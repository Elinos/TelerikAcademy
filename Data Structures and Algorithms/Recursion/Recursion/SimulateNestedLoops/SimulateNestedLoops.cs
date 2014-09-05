using System;
using System.Linq;

namespace SimulateNestedLoops
{
    public static class SimulateNestedLoops
    {
        private static int n = 3;
        private static int[] arr = new int[n];

        static void Main(string[] args)
        {
            GenerateVariations(0);
        }

        private static void GenerateVariations(int index)
        {
            if (index >= n)
                Print(arr);
            else
                for (int i = 1; i <= n; i++)
                {
                    arr[index] = i;
                    GenerateVariations(index + 1);
                }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine(String.Join("", arr));
        }
    }
}
