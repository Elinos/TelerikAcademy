/***************************************************************
 * 
 * 6. Write a program that reads from the console a string 
 * of maximum 20 characters. If the length of the string 
 * is less than 20, the rest of the characters should be 
 * filled with '*'. Print the result string into the console.
 * 
 ***************************************************************/

using System;
using System.Linq;

class TwentyChars
{
    static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(input.Length > 20 ? "Max characters allowed: 20" : input.PadRight(20, '*'));
    }
}