//10. Write a program that finds in given array of 
//integers a sequence of given sum S (if present).

using System;
using System.Collections.Generic;

class SequenceWithSumS
{
    static readonly int[] testArray = {4, 3, 1, 4, 2, 5, 8};
    static readonly int testedSum = 11;
    static readonly List<int> selectedNums = new List<int>();
    static readonly int startIndex = 0;

    static void Main()
    {
        Console.Write("Tested array is:");
        PrintIEnumerable(testArray);
        Console.WriteLine("The following sequences have sum = {0}:", testedSum);
        CurrentSum(startIndex);
    }

    private static void PrintIEnumerable(IEnumerable<int> array)
    {
        Console.WriteLine("[{0}]", String.Join(", ", array));
    }

    private static void CurrentSum(int startIndex)
    {
        int currentSum = 0;
        selectedNums.Clear();
        if (startIndex >= testArray.Length) return;
        
        for (int i = startIndex; i < testArray.Length; i++)
        {
            selectedNums.Add(testArray[i]);
            currentSum += testArray[i];
            if (currentSum == testedSum)
            {
                PrintIEnumerable(selectedNums);
            }
        }   
        startIndex++;
        CurrentSum(startIndex);
    }
}

