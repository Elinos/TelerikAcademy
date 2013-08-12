//14.Write methods to calculate minimum, maximum,
//average, sum and product of given set of integer 
//numbers. Use variable number of arguments.
//15. * Modify your last program and try to make it work 
//for any number type, not just integer (e.g. decimal, 
//float, byte, etc.). Use generic method (read in 
//Internet about generic methods in C#).
using System;

class MinMaxAverageSumProduct
{
    static T GetMin<T>(T[] arr) where T : IComparable<T>
    {
        int best = 0;

        for (int i = 1; i < arr.Length; i++)
            if (arr[i].CompareTo(arr[best]) < 0) best = i;

        return arr[best];
    }

    static T GetMax<T>(T[] arr) where T : IComparable<T>
    {
        int best = 0;

        for (int i = 1; i < arr.Length; i++)
            if (arr[i].CompareTo(arr[best]) > 0) best = i;

        return arr[best];
    }

    static double GetAverage<T>(T[] arr)
    {
        return Convert.ToDouble(GetSum(arr)) / arr.Length;
    }

    static T GetSum<T>(T[] arr)
    {
        dynamic accum = 0;

        for (int i = 0; i < arr.Length; i++) accum += arr[i];

        return accum;
    }

    static T GetProduct<T>(T[] arr)
    {
        dynamic accum = 1;

        for (int i = 0; i < arr.Length; i++) accum *= arr[i];

        return accum;
    }

    static void Main()
    {
        double[] arr = { 5, 8.123 , -1.656, 3 };

        Console.WriteLine("Min = {0}", GetMin(arr));
        Console.WriteLine("Max = {0}", GetMax(arr));
        Console.WriteLine("Average = {0}", GetAverage(arr));
        Console.WriteLine("Sum = {0}", GetSum(arr));
        Console.WriteLine("Product = {0}", GetProduct(arr));
    }
}