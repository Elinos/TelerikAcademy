/***************************************************************
 * 
 * 18. Write a program for extracting all email addresses 
 * from given text. All substrings that match the 
 * format <identifier>@<host>…<domain> should  
 * be recognized as emails.
 *
 ***************************************************************/
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class FindEmail
{
    static void Main()
    {
        foreach (Match match in Regex.Matches(File.ReadAllText("../../input.txt"), @"([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})"))
            Console.WriteLine(match);
    }
}

