//3. Write a program that compares two char arrays 
//lexicographically (letter by letter).

using System;

class CompareCharArrays
{
    static void Main()
    {
        string firstWord = "test";
        string secondWord = "tess";
        char[] firstWordToCharArray = firstWord.ToCharArray();
        char[] secondWordToCharArray = secondWord.ToCharArray();
        if (firstWordToCharArray.Length == secondWordToCharArray.Length)
        {
            for (int i = 0; i < firstWordToCharArray.Length; i++)
            {
                if (firstWordToCharArray[i] != secondWordToCharArray[i])
                {
                    Console.WriteLine("The letters in the tested char arrays are NOT equal!");
                    return;
                }   
            }
            Console.WriteLine("Both char arrays have the same size and all letters are equal!");
        }
        else
        {
            Console.WriteLine("The size of the tested char arrays are not equal!");
        }
    }
}

