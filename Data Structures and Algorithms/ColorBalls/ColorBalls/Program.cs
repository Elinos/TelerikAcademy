using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Program
{

    static void Main()
    {
        var arr = Console.ReadLine().ToCharArray();
        var distinct = arr.Distinct();
        List<long> counts = new List<long>();
        foreach (var ch in distinct)
        {
            long count = arr.Count(c => c == ch);
            if (count > 1)
            {
                counts.Add(count);
            }
        }
        var factCount = counts.Select(x => Factorial(x)).ToList();
        BigInteger prod = 1;
        foreach (BigInteger value in factCount)
        {
            prod *= value;
        }
        Console.WriteLine(Factorial(arr.Length) / prod);
    }

    static BigInteger Factorial(long n)
    {
        BigInteger result = n;
        for (int i = 1; i < n; i++)
        {
            result = result * i;
        }
        return result;
    }
}
