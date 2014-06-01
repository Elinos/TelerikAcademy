using System;

class NthCatalanNumber
{
    //Method that calculates n!
    static decimal Factorial(int n)
    {
        decimal result = 1m;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        decimal nthCatalan = Factorial(2 * n) / (Factorial(n) * Factorial(n + 1));
        Console.WriteLine("N-th Catalan number is: " + nthCatalan);
    }
}
