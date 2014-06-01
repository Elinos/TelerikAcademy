using System;
using System.Globalization;

class FloatingPointNumbersComparision
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        decimal FirstNumber = decimal.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
        Console.Write("Enter second number: ");
        decimal SecondNumber = decimal.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
        if (Math.Abs(FirstNumber - SecondNumber) < 0.000001m)
        {
            Console.WriteLine("The numbers are equal with precision of 0.000001");
        }
        else
        {
            Console.WriteLine("The numbers are NOT equal with precision of 0.000001");
        }
    }
}

