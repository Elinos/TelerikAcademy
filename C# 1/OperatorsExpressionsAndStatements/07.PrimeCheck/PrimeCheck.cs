using System;

class PrimeCheck
{
    static void Main()
    {
        Console.Write("Enter number to check: ");
        int number = int.Parse(Console.ReadLine());
        int devisors = 0;
        for (int i = 2; i <= number; i++)
            if (number % i == 0)
                devisors++;

        if (number != 1 && devisors == 1)
            Console.WriteLine("The number is Prime!");
        else
            Console.WriteLine("The number is NOT Prime!");
    }
}
