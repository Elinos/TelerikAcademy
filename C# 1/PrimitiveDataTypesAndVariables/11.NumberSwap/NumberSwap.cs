using System;

class NumberSwap
{
    static void Main()
    {
        int numberOne = 5;
        int numberTwo = 10;

        Console.WriteLine("The value of the first number is {0}", numberOne);
        Console.WriteLine("The value of the second number is {0}", numberTwo);

        numberOne ^= numberTwo;
        numberTwo ^= numberOne;
        numberOne ^= numberTwo;

        // Other method
        //int tempNumber;
        //tempNumber = numberOne;
        //numberOne = numberTwo;
        //numberTwo = tempNumber;

        // And even one more method
        //numberOne = numberOne + numberTwo;
        //numberTwo = numberOne - numberTwo;
        //numberOne = numberOne - numberTwo;

        Console.WriteLine("And after the swap....");
        Console.WriteLine("The value of the first number is {0}", numberOne);
        Console.WriteLine("The value of the second number is {0}", numberTwo);
    }
}

