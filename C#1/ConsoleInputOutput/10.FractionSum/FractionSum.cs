using System;

class FractionSum
{
    static void Main()
    {
        Console.Write("Enter the number of members to calculate: ");
        int numFractions = int.Parse(Console.ReadLine());
        decimal sum = 1m;
        for (decimal i = 2m; i <= numFractions; i++)
        {
            sum = (i % 2m == 0) ? sum + 1m / i : sum - 1m / i;
        }

        Console.WriteLine("The sum is: {0:0.000}", sum);
    }
}
