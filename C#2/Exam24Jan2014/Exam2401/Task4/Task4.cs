using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task4
{
    class Task4
    {
        static void Main(string[] args)
        {
            if (File.Exists(@"..\..\input.txt"))
                Console.SetIn(new StreamReader(@"..\..\input.txt"));

            string searchWord = Console.ReadLine();
            int numberOfLines = int.Parse(Console.ReadLine());
            string[] separators = { ",", ".", "(", ")", ";", "-", "!", "?", " "};
            string regex = String.Format(@"\b{0}\b", searchWord);


            List<string> lines = new List<string>();
            for (int i = 0; i < numberOfLines; i++)
            {
                string[] splitted = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                lines.Add(String.Join(" ", splitted));
            }

            List<string> orderedLines = new List<string>();
            List<string> replacedLines = new List<string>();
            foreach (var line in lines)
            {
                string lineToReplace = Regex.Replace(line, regex, searchWord.ToUpper(), RegexOptions.IgnoreCase);
                replacedLines.Add(lineToReplace);
            }

            orderedLines = replacedLines.OrderByDescending(y => Regex.Matches(y, regex, RegexOptions.IgnoreCase).Count).ToList();
            foreach (var line in orderedLines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
