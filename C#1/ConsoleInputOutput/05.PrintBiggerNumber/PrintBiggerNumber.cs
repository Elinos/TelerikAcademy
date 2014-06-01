using System;

class PrintBiggerNumber
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        decimal num1 = decimal.Parse(Console.ReadLine());
        Console.Write("Enter another number: ");
        decimal num2 = decimal.Parse(Console.ReadLine());
        Console.WriteLine("The bigger number is: " + Math.Max(num1, num2));
        
    }
}
