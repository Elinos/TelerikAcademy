//9. Write a program that finds the most frequent 
//number in an array.

using System;
using System.Collections.Generic;
using System.Linq;

class MostFrequentNumber
{
    static void Main()
    {
        int[] testArray = new int[13] {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3};
        Console.Write("The most frequent number is {0}({1} times)", MostFrequentNumberInArray(testArray).Item1, MostFrequentNumberInArray(testArray).Item2);
    }

    private static Tuple<int, int> MostFrequentNumberInArray(int[] arr)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        int maxCount = 0;
        int maxItem = 0;
        int currentCount = 0;
        foreach (int item in arr)
        {
            if (dictionary.ContainsKey(item))
            {
                dictionary[item]++;
                currentCount = dictionary[item];
            }
            else
            {
                currentCount = 1;
                dictionary[item] = currentCount;
            }
            if (currentCount > maxCount)
            {
                maxCount = currentCount;
                maxItem = item;
            }
        }
        return new Tuple<int, int>(maxItem, maxCount);
    }
}

