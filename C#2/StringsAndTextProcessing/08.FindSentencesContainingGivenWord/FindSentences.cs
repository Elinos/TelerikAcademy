/***************************************************************
 * 
 * 8. Write a program that extracts from a given text all 
 * sentences containing given word.
 * Example: The word is "in". The text is:
 * 
 * We are living in a yellow submarine. We don't have 
 * anything else. Inside the submarine is very tight. 
 * So we are drinking all the day. We will move out 
 * of it in 5 days.
 * 
 * The expected result is:
 * 
 * We are living in a yellow submarine.
 * We will move out of it in 5 days.
 * 
 * Consider that the sentences are separated by "." 
 * and the words – by non-letter symbols.
 * 
 ***************************************************************/

using System;
using System.IO;
using System.Text.RegularExpressions;

class FindSentences
{
    static void Main()
    {
        foreach (var match in Regex.Matches(File.ReadAllText("../../input.txt"), @"\b[^\.]*?\bin\b[^\.]*?\."))
            Console.WriteLine(match);
    }
}

