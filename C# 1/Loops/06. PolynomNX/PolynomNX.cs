using System;

class PolynomNX
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
        Console.Write("Enter X: ");
        int x = int.Parse(Console.ReadLine());
        decimal s = 0;

        for (int i = 0; i <= n; i++)
        {
            s += Factorial(i) / (decimal)Math.Pow(x, i);
        }

        Console.WriteLine("Result is: " + s);
    }
}
