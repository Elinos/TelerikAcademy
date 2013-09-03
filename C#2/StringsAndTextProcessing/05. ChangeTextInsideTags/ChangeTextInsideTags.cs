/***************************************************************
 * 
 * 5. You are given a text. Write a program that changes 
 * the text in all regions surrounded by the tags 
 * <upcase> and </upcase> to uppercase. The tags 
 * cannot be nested. Example:
 * 
 * We are living in a <upcase>yellow 
 * submarine</upcase>. We don't have 
 * <upcase>anything</upcase> else.
 * 
 * The expected result:
 * We are living in a YELLOW SUBMARINE. We don't have 
 * ANYTHING else.
 * 
 ***************************************************************/

using System;
using System.IO;
using System.Text.RegularExpressions;

class ChangeTextInsideTags
{
    static void Main()
    {
        Console.WriteLine(Regex.Replace(File.ReadAllText("../../input.txt"), @"<upcase>(.*?)</upcase>", x => x.Groups[1].ToString().ToUpper()));
    }
}