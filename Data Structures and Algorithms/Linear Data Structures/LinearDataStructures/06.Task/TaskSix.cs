using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Task
{
    class TaskSix
    {
        static void Main(string[] args)
        {
            var seq = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            List<int> fillteredSeq = FilterSequence(seq);
            Console.WriteLine(String.Join(", ", fillteredSeq));
        }

        public static List<int> FilterSequence(List<int> list)
        {
            List<int> fillteredSeq = list.Where(x => list.Count(c => c == x) % 2 == 0).ToList();
            return fillteredSeq;
        }
    }
}
