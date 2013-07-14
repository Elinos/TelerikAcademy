//7. Sorting an array means to arrange its elements 
//in increasing order. Write a program to sort an 
//array. Use the "selection sort" algorithm: Find the 
//smallest element, move it at the first position, find 
//the smallest from the rest, move it at the second position etc.

using System;

class SelectionSort
{
    static void Main()
    {
        int[] testArray = { 3, 2, 1, 4, 8 };
        Console.Write("Before sort: ");
        PrintArray(testArray);
        SelectionSortArray(testArray);
        Console.Write("After sort : ");
        PrintArray(testArray);
    }

    private static void SelectionSortArray(int[] sortArray)
    {
        int smallest = 0;
        int smallestIndex = 0;

        // advance the position through the entire array 
        for (int i = 0; i < sortArray.Length; i++)
        {
            smallest = sortArray[i];//the smallest value is at index 0
            smallestIndex = i;//store the index of the smallest value

            //find the index of the smallest value
            for (int x = i + 1; x < sortArray.Length; x++)
            {
                if (sortArray[x] < sortArray[i])
                    smallestIndex = x;
            }

            //swap/exchange the smallest value found with last index
            sortArray[i] = sortArray[smallestIndex];
            sortArray[smallestIndex] = smallest;
        }
    }

    private static void PrintArray(int[] array)
    {
        Console.WriteLine(String.Join(", ", array));
    }
}
