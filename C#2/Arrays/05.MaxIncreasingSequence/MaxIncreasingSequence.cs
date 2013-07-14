//5. Write a program that finds the maximal increasing 
//sequence in an array. 

using System;
using System.Linq;

class MaxIncreasingSequence
{
    static void Main()
    {
        int[] testArray = new int[7] {3, 2, 3, 4, 2, 2, 4};
        Console.Write("The maximum sequence of equal elements is: ");
        Console.WriteLine(String.Join(", ", GetMaxIncreasingSequence(testArray)));      
    }

    private static int[] GetMaxIncreasingSequence(int[] arr)
    {
        int currentSequenceStartIndex = 0, currentSequenceLength = 1;
        int maxSequenceStartIndex = 1, maxSequenceLength = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] < arr[i + 1])
            {
                currentSequenceLength++;
                if (currentSequenceLength > maxSequenceLength)
                {
                    maxSequenceLength = currentSequenceLength;
                    maxSequenceStartIndex = currentSequenceStartIndex;
                }
            }
            else
            {
                currentSequenceStartIndex = i + 1;
                currentSequenceLength = 1;
            }
        }
        return arr.Skip(maxSequenceStartIndex).Take(maxSequenceLength).ToArray();
    }
}

