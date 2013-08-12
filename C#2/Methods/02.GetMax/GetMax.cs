//2. Write a method GetMax() with two parameters that 
//returns the bigger of two integers. Write a program 
//that reads 3 integers from the console and prints
//the biggest of them using the method GetMax().
using System;

class GetMax
{
    static void Main()
    {
        int[] numbers = new int[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter number: ");
            numbers[i] = int.Parse(Console.ReadLine());
        }
        int max = GetMaxOfTwoNumbers(GetMaxOfTwoNumbers(numbers[0], numbers[1]), numbers[2]);
        Console.WriteLine("The biggest number is {0}", max);
    }

    private static int GetMaxOfTwoNumbers(int firstNumber, int secondNumber)
    {
        int max = (firstNumber > secondNumber) ? firstNumber : secondNumber;
        return max;
    }
}

