/***************************************************************
 * 
 * 23. Write a program that reads a string from the 
 * console and replaces all series of consecutive 
 * identical letters with a single one. Example: 
 * "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".
 *
 * 
 ***************************************************************/
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class IdenticalLetters
{
    static void Main()
    {
        foreach (Match match in Regex.Matches(Console.ReadLine(), @"([a-z])\1*"))
            Console.Write(match.Groups[1]);
        Console.WriteLine();
    }
}

