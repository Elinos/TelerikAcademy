using System;

class TheBiggestInteger
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        int secondNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter the third number: ");
        int thirdNumber = int.Parse(Console.ReadLine());
        if (firstNumber > secondNumber)
        {
            if (firstNumber > thirdNumber)
            {
                Console.WriteLine("The biggest number is " + firstNumber);
            }
            else
            {
                Console.WriteLine("The biggest number is " + thirdNumber);
            }
        }
        else
        {
            if (secondNumber > thirdNumber)
            {
                Console.WriteLine("The biggest number is " + secondNumber);
            }
            else
            {
                Console.WriteLine("The biggest number is " + thirdNumber);
            }
        }
    }
}
