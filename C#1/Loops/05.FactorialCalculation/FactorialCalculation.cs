using System;
using System.Numerics;


class FactorialCalculation
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K (must be greater than N): ");
        int k = int.Parse(Console.ReadLine());

        //calculate K!/(K-N)!
        BigInteger result = 1;
        for (int i = (k - n) + 1; i <= k; i++)
        {
            result *= i;
        }
        //calculate N!
        BigInteger resultN = 1;
        for (int i = 1; i <= n; i++)
        {
            resultN *= i;
        }
        Console.WriteLine("{0}! * {1}! / ({0}-{1})! = {2}", k, n, result * resultN);
    }
}