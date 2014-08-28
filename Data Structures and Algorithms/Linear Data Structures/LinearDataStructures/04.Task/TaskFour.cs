using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Task
{
    public class TaskFour
    {
        static void Main(string[] args)
        {
            var seq = new List<int> { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };

            List<int> max = GetLongestSequence(seq);
            Console.WriteLine(String.Join(", ", max));
        }

        public static List<int> GetLongestSequence(List<int> list)
        {
            List<int> max = list.Select((n, i) => new { Value = n, Index = i })
                .OrderBy(s => s.Value)
                .Select((o, i) => new { Value = o.Value, Diff = i - o.Index })
                .GroupBy(s => new { s.Value, s.Diff })
                .OrderByDescending(g => g.Count())
                .First()
                .Select(f => f.Value)
                .ToList();
            return max;
        }
    }
}
