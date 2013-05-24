using System;

class DivideBy5And7
{
    static void Main()
    {
        Console.Write("Enter a number (integer) to check: ");
        int numberToCheck = int.Parse(Console.ReadLine());
        // We need to check can we divide the number by 35 (5 * 7), because both 5 and 7 are prime numbers
        if (numberToCheck % 35 == 0)
        {
            Console.WriteLine("The number CAN be divided by 5 and 7 (without reminder) in the same time!");
        }
        else
        {
            Console.WriteLine("The number can NOT be divided by 5 and 7 (without reminder) in the same time!");
        }
    }
}
