//4. Write a method that counts how many times 
//given number appears in given array. Write a 
//test program to check if the method is working 
//correctly.
using System;

public class NumberCount
{
    static void Main()
    {
        int[] array = { 5, 6, 2, -2, 5, 0, 5 };
        int number = 5;
        int count = CountNumberInArray(array, number);
        Console.WriteLine("You can find the number[{0}] {1} times in this array!", number, count);
    }
  
    public static int CountNumberInArray(int[] array, int number)
    {
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == number)
            {
                count++;
            }
        }
        return count;
        //To test this method use the menu => TEST => Run =>All Tests
    }
}
