//2. Write a program that reads two arrays from the 
//console and compares them element by element.

using System;


class CompareArrays
{
    static void Main()
    {
        Console.Write("Enter the size of both arrays: ");
        int arraySize = int.Parse(Console.ReadLine());
        int[] arrayOne = new int[arraySize];
        int[] arrayTwo = new int[arraySize];
        bool areEqual = true;
        for (int i = 0; i < arraySize; i++)
        {
            Console.Write("arrayOne[{0}] = ", i);
            arrayOne[i] = int.Parse(Console.ReadLine());
            Console.Write("arrayTwo[{0}] = ", i);
            arrayTwo[i] = int.Parse(Console.ReadLine());
            if (arrayOne[i] != arrayTwo[i])
            {
                areEqual = false;
            }
        }
        if (areEqual)
        {
            Console.WriteLine("The arrays are equal!");
        }
        else
        {
            Console.WriteLine("The arrays are NOT equal!");
        }
    }
}

