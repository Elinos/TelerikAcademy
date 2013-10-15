using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

static class IEnumerableExtenstions
{
    public static decimal Sum(this IEnumerable list)
    {
        checked
        {
            decimal sum = 0;
            foreach (dynamic item in list)
            {
                sum += (decimal)item;
            }
            return sum;
        }
    }

    public static decimal Product(this IEnumerable list)
    {
        checked
        {
            decimal product = 1;
            foreach (dynamic item in list)
            {
                product *= (decimal)item;
            }
            return product;
        }
    }

    public static dynamic Min(this IEnumerable list)
    {
        if ((list as ICollection).Count == 0) return null;
        dynamic min = null;
        foreach (dynamic item in list)
        {
            if (min == null) min = item;
            if (item < min) min = item;
        }
        return min;
    }

    public static dynamic Max(this IEnumerable list)
    {
        if ((list as ICollection).Count == 0) return null;
        dynamic max = null;
        foreach (dynamic item in list)
        {
            if (max == null) max = item;
            if (item > max) max = item;
        }
        return max;
    }

    public static decimal Average(this IEnumerable list)
    {
        return list.Sum() / (list as ICollection).Count;
    }

    static void Main()
    {
        int[] ints = { -1, 1, 2 };
        decimal[] nums = { 0.5m, 2.5m, 1.23m };
        List<double> doubles = new List<double>(nums.Select(x => (double)x));
        decimal sum = doubles.Sum();
        decimal product = ints.Product();
        int min = ints.Min();
        double max = doubles.Max();
        decimal avg = nums.Average();
        Console.WriteLine("Doubles sum: " + sum);
        Console.WriteLine("Integers product: " + product);
        Console.WriteLine("Integers min: " + min);
        Console.WriteLine("Doubles max: " + max);
        Console.WriteLine("Decimals average: " + avg);
    }
}