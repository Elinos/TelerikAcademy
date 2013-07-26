//8. Write a method that adds two positive integer
//numbers represented as arrays of digits (each 
//array element arr[i] contains a digit; the last digit 
//is kept in arr[0]). Each of the numbers that will be 
//added could have up to 10 000 digits.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SumTwoArraysOfDigits
{
    static void Main()
    {
        byte[] firstArray = { 6, 2, 1, 9 };
        byte[] secondArray = { 1, 4, 6, 7, 9, 9, 9 };

        string sum = SumArrays(firstArray, secondArray);
        Array.Reverse(firstArray);
        Array.Reverse(secondArray);
        Console.WriteLine("{0}", String.Join("", firstArray).PadLeft(sum.Length));
        Console.WriteLine("{0}", "+".PadLeft(sum.Length));
        Console.WriteLine("{0}", String.Join("", secondArray).PadLeft(sum.Length));
        Console.WriteLine(new string('-', sum.Length));
        Console.WriteLine("{0}", sum.PadLeft(sum.Length));
    }

    private static string SumArrays(byte[] firstArray, byte[] secondArray)
    {
        List<byte> maxArray = new List<byte>();
        List<byte> minArray = new List<byte>();
        if (firstArray.Length > secondArray.Length)
        {
            maxArray.AddRange(firstArray);
            minArray.AddRange(secondArray);
        }
        else
        {
            maxArray.AddRange(secondArray);
            minArray.AddRange(firstArray);
        }

        int minLength = minArray.Count;
        int maxLength = maxArray.Count;
        int addition = 0;
        int sum;
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < minLength; i++)
        {
            sum = minArray[i] + maxArray[i] + addition;
            if (sum >= 10)
            {
                addition = 1;
                sum = sum % 10;
                result.Append(sum);
            }
            else
            {
                result.Append(sum);
                addition = 0;
            }
        }

        for (int j = minLength; j < maxLength; j++)
        {
            sum = maxArray[j] + addition;
            if (sum >= 10)
            {
                addition = 1;
                sum = sum % 10;
                result.Append(sum);
            }
            else
            {
                result.Append(sum);
                addition = 0;
            }
        }
        if (addition == 1)
        {
            result.Append(1);
        }
        char[] reversed = (result.ToString()).ToCharArray();
        Array.Reverse(reversed);
        return new string(reversed);
    }
}
