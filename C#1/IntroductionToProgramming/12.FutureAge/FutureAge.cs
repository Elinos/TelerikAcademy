using System;

class FutureAge
{
    static void Main()
    {
        Console.WriteLine("Please enter your age:");
        int currentAge = int.Parse(Console.ReadLine());
        int futureAge = currentAge + 10;
        Console.WriteLine("After ten years you will be {0} years old", futureAge);
    }
}

