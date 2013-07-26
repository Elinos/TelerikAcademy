//10. Write a program to calculate n! for each n in the 
//range [1..100]. Hint: Implement first a method 
//that multiplies a number represented as array of 
//digits by given integer number.
using System;
using System.Numerics;

class Factorials
{
    public static BigInteger CalculateFactorialMultiplyingIndices(int[] array, int index)
    {
        BigInteger factOfGivenNumber = 1;
        for (int i = 1; i <= index; i++)
        {
            factOfGivenNumber *= array[i];
        }
        return factOfGivenNumber;
    }
    static void Main()
    {
        int[] hundredNumbers = new int[100];
        for (int i = 1; i < 100; i++)
        {
            hundredNumbers[i] = i;
        }
        foreach (int index in hundredNumbers)
        {
            Console.WriteLine(CalculateFactorialMultiplyingIndices(hundredNumbers, index));
        }
    }
}