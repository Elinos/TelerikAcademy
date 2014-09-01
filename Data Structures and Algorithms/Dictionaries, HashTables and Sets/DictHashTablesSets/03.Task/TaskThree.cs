using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Task
{
    class TaskThree
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"../../words.txt");
            using (reader)
            {
                string text = reader.ReadToEnd();
                char[] separators = { ' ', '.', ',', '!', '–', '?', '-', '\r', '\n' };
                string[] values = text.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                var counts = values
                    .GroupBy(x => x)
                    .Select(g => new { Value = g.Key, Count = g.Count() })
                    .OrderBy(g => g.Count).ToList();

                counts.ForEach(c => Console.WriteLine("{0} -> {1}", c.Value, c.Count));
            }
        }
    }
}
