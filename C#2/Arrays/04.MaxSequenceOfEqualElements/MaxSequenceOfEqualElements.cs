//4. Write a program that finds the maximal sequence 
//of equal elements in an array.
using System;
using System.Linq;

class MaxSequenceOfEqualElements
{
    static void Main()
    {
        int[] testArray = new int[10] { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
        Console.Write("The maximum sequence of equal elements is: ");
        Console.WriteLine(String.Join(", ", GetMaxSequence(testArray)));      
    }

    private static int[] GetMaxSequence(int[] arr)
    {

        int value = arr[0];

        int currentSequenceStartIndex = 0;
        int currentSequenceLength = 1;

        int maxSequenceStartIndex = 0;
        int maxSequenceLength = 0;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == value)
            {
                currentSequenceLength++;
                continue;
            }

            if (currentSequenceLength > maxSequenceLength)
            {
                maxSequenceLength = currentSequenceLength;
                maxSequenceStartIndex = currentSequenceStartIndex;
            }

            currentSequenceStartIndex = i;
            currentSequenceLength = 1;
            value = arr[i];
        }

        if (currentSequenceLength > maxSequenceLength)
        {
            maxSequenceLength = currentSequenceLength;
            maxSequenceStartIndex = currentSequenceStartIndex;
        } 

        return arr.Skip(maxSequenceStartIndex).Take(maxSequenceLength).ToArray();
    }

}

