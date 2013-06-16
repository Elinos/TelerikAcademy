using System;
using System.Numerics;

class TailOfZeroes
{
    /* Used for the other method to calculate the trailing zeroes
    static BigInteger Factorial(double n)
    {
        BigInteger result = 1;
        Console.Write("Calculating factorial ");
        for (int i = 1; i <= n; i++)
        {
            if (i % 5000 == 0)
            {
                Console.Write('.');
            }
            result *= i;
        }
        return result;
    }
    */
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        int numberOfTrailingZeroes = 0;
        int powerOfFive = 1;
        int numberOfFactors = 1;
        while (numberOfFactors != 0)
        {
            numberOfFactors = n / (int)Math.Pow(5, powerOfFive);
            numberOfTrailingZeroes += numberOfFactors;
            powerOfFive++;
        }
        Console.WriteLine("Number of trailing zeroes is: " + numberOfTrailingZeroes);

        /* Other method to calculate the trailing zeroes
        BigInteger result = Factorial(n);
        int countOfZeroes = 0;
        Console.WriteLine();
        Console.Write("Calculating number of zeroes ");
        while (result % 10 == 0)
        {
            result /= 10;
            countOfZeroes++;
            if (countOfZeroes % 1000 == 0)
            {
                Console.Write('.');
            }
        }
        Console.WriteLine();
        Console.WriteLine("Number of trailing zeroes is: " + countOfZeroes);
         */
    }
}
