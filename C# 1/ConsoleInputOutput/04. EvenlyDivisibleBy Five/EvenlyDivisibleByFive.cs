using System;

class EvenlyDivisibleByFive
{
    static void Main()
    {
        Console.Write("Enter first positive number: ");
        decimal positiveNumber1 = decimal.Parse(Console.ReadLine());
        Console.Write("Enter second positive number: ");
        decimal positiveNumber2 = decimal.Parse(Console.ReadLine());
        int countOfDisibleNumbers = (int)Math.Abs(positiveNumber1 - positiveNumber2) / 5;
        if (positiveNumber1 % 5 == 0 || positiveNumber2 % 5 == 0)
            countOfDisibleNumbers++;

        Console.WriteLine("Total number of divisible by five numbers between {0} and {1} is {2}", 
                            Math.Min(positiveNumber1, positiveNumber2), Math.Max(positiveNumber1, positiveNumber2), countOfDisibleNumbers);

    }
}
