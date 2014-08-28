using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Task
{
    class TaskThree
    {
        static void Main(string[] args)
        {
            var sequence = ReadInput();
            sequence.Sort();
            Console.WriteLine(String.Join(", ", sequence));
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
