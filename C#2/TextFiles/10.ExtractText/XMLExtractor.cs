//Write a program that extracts from given XML file all the text without the tags. 

using System;
using System.IO;
using System.Text.RegularExpressions;

class XMLExtractor
{
    static void Main()
    {
        using (StreamReader input = new StreamReader("../../input.txt"))
            for (string line; (line = input.ReadLine()) != null; )
                foreach (Match match in Regex.Matches(line, @"(?<=>).*(?=<)" ))
                    Console.WriteLine(match);       
    }
}
