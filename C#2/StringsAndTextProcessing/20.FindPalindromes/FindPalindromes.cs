/***************************************************************
 * 
 * 20. Write a program that extracts from a given text all   
 * palindromes, e.g. "ABBA", "lamal", "exe". 
 *
 ***************************************************************/
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class FindPalindromes
{
    static bool IsPalindrome(string word)
    {
        return word.Length > 1 ? word.SequenceEqual(word.Reverse()) : false;
    }
    static void Main()
    {
        foreach (Match match in Regex.Matches(File.ReadAllText("../../input.txt"), @"\b(\w+?)\b"))
            if (IsPalindrome(match.Value)) Console.WriteLine(match.Value);
    }
}

