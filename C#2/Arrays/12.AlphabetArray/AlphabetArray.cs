//12. Write a program that creates an array containing 
//all letters from the alphabet (A-Z). Read a word 
//from the console and print the index of each of its 
//letters in the array.
using System;

class AlphabetArray
{
    static void Main()
    {
        char[] alphabetArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        Console.Write("Enter a word: ");
        string word = Console.ReadLine().ToUpper();
        Console.WriteLine("Letters of the word {0} like indexes in the alphabet array:", word);
        for (int i = 0; i < word.Length; i++)
        {
            Console.Write("| {0}({1}) |", word[i], Array.BinarySearch(alphabetArray, word[i]));
        }
        Console.WriteLine();
    }
}

