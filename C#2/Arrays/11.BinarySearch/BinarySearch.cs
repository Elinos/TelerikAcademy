//11. Write a program that finds the index of given 
//element in a sorted array of integers by using the 
//binary search algorithm (find it in Wikipedia).
using System;

class BinarySearch
{
    static void Main()
    {
        int[] testArray = new int[10] { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        int numberToLookFor = -8;
        Console.WriteLine("We are giiven the array:");
        PrintArray(testArray);
        Console.WriteLine("...and it looks like this sorted:");
        Array.Sort(testArray);
        PrintArray(testArray);
        if (BinarySearchInArray(numberToLookFor, testArray) != -1)
        {
            Console.WriteLine("The number {0} is located on position {1}", numberToLookFor, BinarySearchInArray(numberToLookFor, testArray));            
        }
        else
        {
            Console.WriteLine("The number {0} was not found in the test array!", numberToLookFor);
        }
    }

    private static int BinarySearchInArray(int number, int[] sortedArray)
    {
        int min = 0;
        int max = sortedArray.Length;
        int mid = (min + max) / 2;
        while (min <= max)
        {
            mid = (min + max) / 2;
            if (number < sortedArray[mid])
            {
                max = mid - 1;
            }
            else if (number > sortedArray[mid])
            {
                min = mid + 1;
            }
            else return mid;
        }
        return -1;
    }

    private static void PrintArray(int[] array)
    {
        Console.WriteLine(String.Join(", ", array));
    }
}

