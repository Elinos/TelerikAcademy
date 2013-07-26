//9. Write a method that return the maximal element
//in a portion of array of integers starting at given 
//index. Using it write another method that sorts an 
//array in ascending / descending order.
using System;

class SortArray
{
    static void PrintArray(int[] arr)
    {
        Console.WriteLine(String.Join(" ", arr));
    }

    static void Swap(int[] arr, int i, int j)
    {
        int t = arr[i];
        arr[i] = arr[j];
        arr[j] = t;
    }

    // Returns the min/max element 
    static int GetBestFromPosition(int[] arr, int i, bool descending)
    {
        int best = i;

        for (i++; i < arr.Length; i++)
            if (descending ? arr[i] < arr[best] : arr[best] < arr[i])
                best = i;

        return best;
    }

    static void SelectionSort(int[] arr, bool descending = false)
    {
        for (int i = 0; i < arr.Length; i++)
            Swap(arr, i, GetBestFromPosition(arr, i, descending));
    }

    static void Main()
    {
        int[] arr = { 1, -3, 2, 3, 6, -7 };

        // Ascending
        SelectionSort(arr);
        PrintArray(arr);

        // Descending
        SelectionSort(arr, true);
        PrintArray(arr);
    }
}

