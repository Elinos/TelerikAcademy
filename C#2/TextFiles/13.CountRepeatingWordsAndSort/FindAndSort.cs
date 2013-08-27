//Write a program that reads a list of words from a file words.txt and
//finds how many times each of the words is contained in another file test.txt.
//The result should be written in the file result.txt and the words should be
//sorted by the number of their occurrences in descending order.
//Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Security;
using System.Linq;

class FindAndSort
{
    static void Main()
    {
        try
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            MatchWords(dict);
            var sortedDict = SortDictionary(dict);
            WriteOutput(sortedDict);
        }

        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (SecurityException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
        }
    }
  
    private static Dictionary<string, int> SortDictionary(Dictionary<string, int> dict)
    {
        return (from entry in dict orderby entry.Value ascending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
    }
  
    private static void MatchWords(Dictionary<string, int> dict)
    {
        using (StreamReader input = new StreamReader("../../test.txt"))
        {
            string regex = @"\b(" + String.Join("|", File.ReadAllLines("../../words.txt")) + @")\b";
            for (string line; (line = input.ReadLine()) != null;)
            {
                foreach (Match match in Regex.Matches(line, regex))
                {
                    if (!dict.ContainsKey(match.Value))
                        dict.Add(match.Value, 1);
                    else
                        dict[match.Value]++;
                }
            }
        }
    }
  
    private static void WriteOutput(Dictionary<string, int> dict)
    {
        using (StreamWriter output = new StreamWriter("../../result.txt"))
            foreach (var key in dict)
                output.WriteLine("{0}: {1}", key.Key, key.Value);
    }
}
