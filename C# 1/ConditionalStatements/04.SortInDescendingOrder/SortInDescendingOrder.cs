using System;

class SortInDescendingOrder
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int secondNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter third number: ");
        int thirdNumber = int.Parse(Console.ReadLine());

        if (firstNumber >= secondNumber)
        {
            if (firstNumber >= thirdNumber)
            {
                if (secondNumber >= thirdNumber)
                {
                    Console.WriteLine("Numbers in descending order are: {0}, {1}, {2}", firstNumber, secondNumber, thirdNumber);
                }
                else
                {
                    Console.WriteLine("Numbers in descending order are: {0}, {1}, {2}", firstNumber, thirdNumber, secondNumber);
                }
            }
        }
        else if (secondNumber >= firstNumber)
        {
            if (secondNumber >= thirdNumber)
            {
                if (firstNumber >= thirdNumber)
                {
                    Console.WriteLine("Numbers in descending order are: {0}, {1}, {2}", secondNumber, firstNumber, thirdNumber);
                }
                else
                {
                    Console.WriteLine("Numbers in descending order are: {0}, {1}, {2}", secondNumber, thirdNumber, firstNumber);
                }
            }
            else
            {
                Console.WriteLine("Numbers in descending order are: {0}, {1}, {2}", thirdNumber, secondNumber, firstNumber);
            }
        }
        else
        {
            if (secondNumber >= firstNumber)
            {
                Console.WriteLine("Numbers in descending order are: {0}, {1}, {2}", thirdNumber, secondNumber, firstNumber);
            }
            else
            {
                Console.WriteLine("Numbers in descending order are: {0}, {1}, {2}", thirdNumber, firstNumber, secondNumber);
            }
        }
    }
}
