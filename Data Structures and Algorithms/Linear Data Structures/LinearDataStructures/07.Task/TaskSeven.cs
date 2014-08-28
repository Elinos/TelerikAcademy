using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Task
{
    class TaskSeven
    {
        static void Main(string[] args)
        {
            var seq = new List<int> { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            List<Number> fillteredSeq = FilterSequence(seq);
            foreach (var number in fillteredSeq)
            {
                Console.WriteLine("{0} -> {1}", number.Value, number.Count);
            }
        }

        public static List<Number> FilterSequence(List<int> list)
        {
            List<Number> fillteredSeq = list.GroupBy(x => x).OrderBy(x => x.Key).Select(x => new Number(x.Key, x.Count())).ToList();
            return fillteredSeq;
        }
    }
}
