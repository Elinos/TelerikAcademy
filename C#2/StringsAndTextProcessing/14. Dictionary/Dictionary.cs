/***************************************************************
 * 
 * 14. A dictionary is stored as a sequence of text lines 
 * containing words and their explanations. Write a 
 * program that enters a word and translates it by 
 * using the dictionary. Sample dictionary:
 * 
 * .NET – platform for applications from Microsoft
 * CLR – managed execution environment for .NET
 * namespace – hierarchical organization of classes
 * 
 ***************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Dictionary
{
    static void Main()
    {
        Dictionary<string, string> dict = new Dictionary<string, string>();
        foreach (Match match in Regex.Matches(File.ReadAllText("../../input.txt"), @"(.*?) – (.*)"))
            dict.Add(match.Groups[1].Value.ToLower(), match.Groups[2].Value);
        Console.WriteLine(dict[Console.ReadLine().ToLower()]);
    }
}
