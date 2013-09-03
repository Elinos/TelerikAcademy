/***************************************************************
 * 
 * 22. Write a program that reads a string from the   
 * console and lists all different words in the string 
 * along with information how many times each 
 * word is found. 
 *
 ***************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class AllDifferentWords
{
    static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach (Match match in Regex.Matches(input, @"\b\w+\b"))
        {
            if (wordCount.ContainsKey(match.Value))
                wordCount[match.Value]++;
            else
                wordCount.Add(match.Value, 1);
        }
        foreach (var key in wordCount)
            Console.WriteLine("{0} - {1}", key.Key, key.Value);
    }
}

