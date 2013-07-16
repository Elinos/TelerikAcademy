//21. Write a program that reads two numbers N and K 
//and generates all the combinations of K distinct 
//elements from the set [1..N].
using System;

class Combinations
{
    static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        int k = int.Parse(Console.ReadLine());
        int[] combinations = new int[k];
        Console.WriteLine("All the combinations of {0} elements from the set [1..{1}]:", k, n);
        GenerateCombinations(combinations, 0, 1, n);
    }

    static void GenerateCombinations(int[] arr, int index, int startNum, int n)
    {
        if (index >= arr.Length)
        {
            Console.WriteLine("[" + String.Join(", ", arr) + "]");
        }
        else
        {
            for (int i = startNum; i <= n; i++)
            {
                arr[index] = i;
                GenerateCombinations(arr, index + 1, i + 1, n);
            }
        }
    }
}
