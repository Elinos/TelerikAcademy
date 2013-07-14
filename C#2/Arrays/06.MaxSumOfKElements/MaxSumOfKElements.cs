//6. Write a program that reads two integer numbers 
//N and K and an array of N elements from the 
//console. Find in the array those K elements that 
//have maximal sum.

using System;
using System.Linq;

class MaxSumOfKElements
{
    static void Main()
    {
        Console.Write("Enter the size of the array(N): ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] testArray = new int[arraySize];

        for (int i = 0; i < arraySize; i++)
        {
            Console.Write("arrayOne[{0}] = ", i);
            testArray[i] = int.Parse(Console.ReadLine());
        }
        Console.Write("Enter the length of the sequence(K): ");
        int seqLength = int.Parse(Console.ReadLine());
        Console.Write("The sequence with the maximum sum of K elements is: ");
        Console.WriteLine(String.Join(", ", FindBestSubsequenceOfKElements(testArray, seqLength)));
    }

    private static int[] FindBestSubsequenceOfKElements(int[] arr, int seqLength)
    {
        decimal maxSum = int.MinValue;
        decimal currentSum = 0;

        int startIndex = 0;

        for (int index = 0; index <= arr.Length - seqLength; index++)
        {
            for (int i = 0; i < seqLength; i++)
            {
                currentSum += arr[index + i];
            }
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                startIndex = index;
            }
            currentSum = 0;
        }

        return arr.Skip(startIndex).Take(seqLength).ToArray();
    }
}

