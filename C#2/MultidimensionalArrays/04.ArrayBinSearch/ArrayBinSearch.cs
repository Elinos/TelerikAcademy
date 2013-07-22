//Write a program, that reads from the console an array of N integers and an integer K, sorts the array
//and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.
using System;

class ArrayBinSearch
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("array[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter K: ");
        int k = int.Parse(Console.ReadLine());
        Array.Sort(array);
        FindMaxNumber(array, k);
    }
  
    private static void FindMaxNumber(int[] array, int k)
    {
        int maxNumberIndex = Array.BinarySearch(array, k);
        while (maxNumberIndex < 0)
        {
            if (k < array[0])
            {
                break;
            }
            k--;
            maxNumberIndex = Array.BinarySearch(array, k);
        }
        if (maxNumberIndex < 0)
        {
            Console.WriteLine("Number not found!");
        }
        else
        {
            Console.WriteLine("Number {0}(that is <= K) found at index [{1}]",array[maxNumberIndex], maxNumberIndex);
        }
    }
}

