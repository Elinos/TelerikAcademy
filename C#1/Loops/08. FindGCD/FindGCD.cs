using System;

class FindGCD
{
    //Method that calculates the greatest common divisor of the numbers a and b
    static decimal GCD(decimal a, decimal b) 
    {
        while (a != b)
        {
            if (a > b)
                a = a - b;
            else
                b = b - a;
        }
        return a;
    }

    static void Main()
    {
        Console.Write("Enter first number: ");
        decimal firstNum = decimal.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        decimal secondNum = decimal.Parse(Console.ReadLine());

        Console.WriteLine("The greatest common divisor of {0} and {1} is: {2}", firstNum, secondNum, GCD(firstNum, secondNum));
    }
}
