using System;
using System.Linq;

class FindTheSequenceWithMaxSum
{
    static void Main()
    {
        int[] testArray = new int[10] { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        Console.Write("The sequence with the maximum sum is: ");
        PrintArray(FindBestSubsequenceOfKElements(testArray));
    }

    private static int[] FindBestSubsequenceOfKElements(int[] arr)
    {
        decimal result = decimal.MinValue;
        decimal sum = 0;
        int tempStart = 0;

        int startIndex = 0;
        int endIndex = 0;

        for (int index = 0; index < arr.Length; index++)
        {
            sum += arr[index];
            if (sum > result)
            {
                result = sum;
                startIndex = tempStart;
                endIndex = index;
            }
            if (sum < 0)
            {
                sum = 0;
                tempStart = index + 1;
            }
        }
        int seqLength = (endIndex + 1) - startIndex;

        return arr.Skip(startIndex).Take(seqLength).ToArray();
    }

    private static void PrintArray(int[] array)
    {
        Console.WriteLine(String.Join(", ", array));
    }
}

