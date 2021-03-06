﻿using System;
using System.Linq;

namespace _04.Permutations
{
    class Permuttions
    {
        static void Main()
        {
            var n = 3;
            int[] arr = new int[n];
            for (int i = 1; i <= n; i++)
            {
                arr[i - 1] = i;
            }
            GeneratePermutations(arr, 0);
        }

        static void GeneratePermutations<T>(T[] arr, int k)
        {
            if (k >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                GeneratePermutations(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        static void Print<T>(T[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
