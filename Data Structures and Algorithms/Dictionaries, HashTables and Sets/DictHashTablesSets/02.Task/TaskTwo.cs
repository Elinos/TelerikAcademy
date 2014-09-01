using System;
using System.Linq;

namespace _02.Task
{
    class TaskTwo
    {
        static void Main(string[] args)
        {
            var arrayOfStings = new string[] {"C#", "SQL", "PHP", "PHP", "SQL", "SQL"};
            var elementsOddNumberOfTimes = arrayOfStings
                .GroupBy(x => x)
                .Where(g => g.Count() % 2 == 1)
                .Select(g => g.Key)
                .ToArray();
            foreach (var element in elementsOddNumberOfTimes)
            {
                Console.WriteLine(element);
            }
        }
    }
}
