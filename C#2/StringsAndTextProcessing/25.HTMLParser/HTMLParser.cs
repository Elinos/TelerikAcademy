/***************************************************************
 * 
 * 25. Write a program that extracts from given HTML  
 * file its title (if available), and its body text without  
 * the HTML tags.
 * 
 ***************************************************************/
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class HTMLParser
{
    static void Main()
    {
        string input = File.ReadAllText("../../input.txt");
        string title = Regex.Match(input, @"<title>(.*?)</title>").Groups[1].Value;
        string bodyWithTags = Regex.Match(input, @"<body>(.*?)</body>", RegexOptions.Singleline).Groups[1].Value;
        string bodyText = Regex.Replace(Regex.Replace(bodyWithTags, @"<.*?>", " "), @"\s+", " ");
        Console.WriteLine("Title: {0}\nBody text :{1}", title, bodyText);
    }
}

