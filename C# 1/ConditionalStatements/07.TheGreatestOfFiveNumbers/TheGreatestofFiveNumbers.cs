using System;
using System.Linq;


class TheGreatestofFiveNumbers
{
    static void Main()
    {
        //int[] numbers = new int[5];
        //for (int i = 0; i < 5; i++)
        //{
        //    Console.Write("Enter number({0}): ", i + 1);
        //    numbers[i] = int.Parse(Console.ReadLine());
        //}
        //Console.WriteLine("The greatest of those numbers is {0}", numbers.Max());


        // Another way:
        int number = 0;
        int maxNumber = int.MinValue;
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Enter a number({0}): ", i + 1);
            number = int.Parse(Console.ReadLine());
            if (number > maxNumber)
            {
                maxNumber = number;
            }
        }
        Console.WriteLine("The greatest of those numbers is {0}", maxNumber);
    }
}
