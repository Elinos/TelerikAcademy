using System;

class OddOrEven
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        if (number % 2 == 0) //if the number is even there will be no reminder when divided by 2
        {
            Console.WriteLine("This number is even");
        }
        else
        {
            Console.WriteLine("This number is odd");
        }
    }
}
