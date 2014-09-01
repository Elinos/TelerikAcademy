using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Task
{
    class TaskOne
    {
        static void Main(string[] args)
        {
            var array = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            FindOccurrences(array);
        }

        private static void FindOccurrences(double[] array)
        {
            var dict = new SortedDictionary<double, int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (!dict.ContainsKey(array[i]))
                {
                    dict[array[i]] = 0;
                }
                dict[array[i]]++;
            }
            foreach (var number in dict)
            {
                Console.WriteLine("{0} -> {1} times", number.Key, number.Value);
            }
        }
    }
}
