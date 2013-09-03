/***************************************************************
 * 
 * 13. Write a program that reverses the words in given 
 * sentence.
 * Example: "C# is not C++, not PHP and not Delphi!" 
 *  "Delphi not and PHP, not C++ not is C#!".
 * 
 ***************************************************************/
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class ReverseWords
{
    static void Main()
    {
        Stack words = new Stack();
        Queue separators = new Queue();
        StringBuilder sb = new StringBuilder();
        foreach (Match match in Regex.Matches(File.ReadAllText("../../input.txt"), @"([ ,!""\?]+)|([^ ,!""\?]+)"))
        {
            separators.Enqueue(match.Groups[1]);
            words.Push(match.Groups[2]);
        }
        while (words.Count != 0 && separators.Count != 0)
        {
            if (words.Count > 0)
                sb.Append(words.Pop());
            if (separators.Count > 0)
                sb.Append(separators.Dequeue());
        }
        Console.WriteLine(sb);
    }
}
