//14. Write a program that sorts an array of strings using
//using the quick sort algorithm.
using System;
using System.Collections.Generic;
using System.Linq;

class QuickSortAnArray
{
    static void Main()
    {
        string[] testArray = new string[10] { "d", "n", "r", "x", "z", "s", "b", "a", "r", "h" };
        Console.WriteLine("Test array:");
        PrintArray(testArray);
        Console.WriteLine("Quick-sorted array:");
        List<string> listArr = testArray.ToList();
        string[] sortedArray = QuickSort(listArr).ToArray();
        PrintArray(sortedArray);
    }

    private static List<string> QuickSort(List<string> arr)
    {
        List<string> less = new List<string>();
        List<string> greater = new List<string>();
        if (arr.Count < 2)
            return arr;
        string pivot = arr[arr.Count / 2];
        arr.Remove(pivot);
        foreach (var x in arr)
        {
            if (x.CompareTo(pivot) <= 0)
            {
                less.Add(x);
            }
            else
            {
                greater.Add(x);
            }
        }
        List<string> resultSet = new List<string>();
        resultSet.AddRange(QuickSort(less));
        resultSet.Add(pivot);
        resultSet.AddRange(QuickSort(greater));
        return resultSet;
    }

    private static void PrintArray(string[] array)
    {
        Console.WriteLine(String.Join(", ", array));
    }
}