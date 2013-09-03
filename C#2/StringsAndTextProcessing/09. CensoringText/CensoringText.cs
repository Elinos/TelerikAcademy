/***************************************************************
 * 
 * 9. We are given a string containing a list of forbidden 
 * words and a text containing some of these words. 
 * Write a program that replaces the forbidden words 
 * with asterisks. Example:
 * 
 * Microsoft announced its next generation PHP 
 * compiler today. It is based on .NET Framework 4.0 
 * and is implemented as a dynamic language in CLR.
 * 
 * 		Words: "PHP, CLR, Microsoft"
 *  	The expected result:
 *  
 * ********* announced its next generation *** 
 * compiler today. It is based on .NET Framework 4.0 
 * and is implemented as a dynamic language in ***.
 * 
 ***************************************************************/

using System;
using System.IO;
using System.Text.RegularExpressions;

class CensoringText
{
    static void Main()
    {
        Console.WriteLine(Regex.Replace(File.ReadAllText("../../text.txt"), @"\b(" + File.ReadAllText("../../words.txt").Replace(", ", "|") + @")\b", x => new string('*', x.Length)));
    }
}
