using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Task
{
    class TaskOne
    {
        static void Main(string[] args)
        {
            var sequence = new List<int>();
            sequence = ReadInput();
            var sum = sequence.Sum();
            var average = sequence.Average();
            Console.WriteLine("The sum of elements is {0} and the average is {1}", sum, average);
        }

        private static List<int> ReadInput()
        {
            List<string> rawInput = new List<string>();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == String.Empty)
                {
                    break;
                }
                rawInput.Add(line);
            }
            return rawInput.Select(int.Parse).ToList();
        }
    }
}
