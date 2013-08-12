using System;

class LeapYear
{
    static void Main()
    {
        Console.Write("Enter a year: ");
        int yearToCheck = int.Parse(Console.ReadLine());
        bool isLeap = DateTime.IsLeapYear(yearToCheck);
        if (isLeap)
            Console.WriteLine("This is a leap year!");
        else
            Console.WriteLine("This is NOT a leap year!");
    }
}

