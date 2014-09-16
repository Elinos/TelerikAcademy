using System;
using System.Collections.Generic;
using System.Linq;

namespace Task5
{
    class Program
    {
        static int[] arr;
        static List<int> used = new List<int>();
        static int totalCount = 0;
        static int k;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            k = int.Parse(Console.ReadLine());

            try
            {
                for (int i = 0; i < n; i++)
                {
                    var minIndex = FindNextMin(i);
                    SwapTillAtPosition(minIndex, i);
                }
                Console.WriteLine(totalCount);
            }
            catch (Exception)
            {
                Console.WriteLine(-1);
            }
        }

        private static void SwapTillAtPosition(int minIndex, int to)
        {
            var currentPosition = minIndex;
            while (currentPosition != to)
            {
                Swap(currentPosition, k - 1);
                totalCount++;
                currentPosition = currentPosition - k + 1;
            }
        }

        private static void Swap(int currentPosition, int k)
        {
            var temp = arr[currentPosition - k];
            arr[currentPosition - k] = arr[currentPosition];
            arr[currentPosition] = temp;
        }

        private static int FindNextMin(int startingIndex)
        {
            var currentMin = int.MaxValue;
            var currentMinIndex = 0;

            for (int i = startingIndex; i < arr.Length; i++)
            {
                if (arr[i] < currentMin)
                {
                    currentMin = arr[i];
                    currentMinIndex = i;
                }
            }
            return currentMinIndex;
        }
    }
}
