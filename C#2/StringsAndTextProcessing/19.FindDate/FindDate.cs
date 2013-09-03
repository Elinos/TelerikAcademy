/***************************************************************
 * 
 * 19. Write a program that extracts from a given text all  
 * dates that match the format DD.MM.YYYY. Display 
 * them in the standard date format for Canada.  
 *
 ***************************************************************/
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class FindDate
{
    static void Main()
    {
        foreach (Match match in Regex.Matches(File.ReadAllText("../../input.txt"), @"[0-9]{2}.[0-9]{2}.[0-9]{4}"))
            Console.WriteLine(DateTime.Parse(match.Value).ToString(new CultureInfo("en-CA")));
    }
}

