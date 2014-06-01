using System;

class SumOfThreeIntegers
{
    static void Main()
    {
        Console.Write("Enter the first integer: ");
        int firstInteger = int.Parse(Console.ReadLine());
        Console.Write("Enter the second integer:");
        int secondInteger = int.Parse(Console.ReadLine());
        Console.Write("Enter the third intger: ");
        int thirdInteger = int.Parse(Console.ReadLine());

        Console.WriteLine("The sum of all integers is: {0}", firstInteger + secondInteger + thirdInteger);
    }
}
