/*Task 16. We are given an array of integers and a number S. Write a program to find if there exists
a subset of the elements of the array that has a sum S. Example:
        arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)*/
using System;
using System.Collections.Generic;

class SubsetSum
{
    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    static void Main()
    {
        int[] testArray = new int[] { 2, 1, 2, 4, 3, 5, 2, 6 };
        int sumToFind = 14;
        List<int> printOut = new List<int>();
        List<string> indexCombinations = new List<string>();
        decimal exponent = 1;

        for (int index = 0; index < testArray.Length; index++)
        {
            exponent *= 2;
        }
        for (int index = 1; index < exponent; index++)
        {
            int currentValue = 0;
            for (int value = 0; value < testArray.Length; value++)
            {
                currentValue += ((index >> value) & 1) * testArray[value];
            }
            if (currentValue == sumToFind)
            {
                string temp = Convert.ToString(index, 2).PadLeft(testArray.Length, '0');
                indexCombinations.Add(Reverse(temp));
            }

        }
        if (indexCombinations.Count > 0)
        {
            Console.WriteLine("The following members of the test array have sum = {0}:", sumToFind);
            Print(indexCombinations, printOut, testArray);
        }
        else
        {
            Console.WriteLine("There is no subset of ellements with sum = {0}!", sumToFind);
        }
    }

    private static void Print(List<string> indexCombinations, List<int> printOut, int[] testArray)
    {
        foreach (var item in indexCombinations)
        {
            printOut.Clear();

            for (int i = 0; i < item.Length; i++)
            {
                if (item[i] == '1')
                    printOut.Add(testArray[i]);
            }
            Console.WriteLine("[{0}]", String.Join(", ", printOut));
        }
    }
}