using System;

class TheSumOfNNumbers
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        decimal theSumOfNNumbers = decimal.Parse(Console.ReadLine());
        bool isRunning = true;
        while (isRunning)
        {
            Console.Write("Enter number to add or quit to end the program: ");
            string stringToCheck = Console.ReadLine();
            if (stringToCheck != "quit")
            {
                decimal numberToAdd = decimal.Parse(stringToCheck);
                theSumOfNNumbers += numberToAdd;
                Console.WriteLine("The sum of all numbers is: {0}", theSumOfNNumbers);
            }
            else
            {
                isRunning = false;
                return;
            }
        }
    }
}
