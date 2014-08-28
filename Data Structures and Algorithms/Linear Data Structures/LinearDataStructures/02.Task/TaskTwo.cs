using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Task
{
    class TaskTwo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many numbers you will enter?");
            var N = int.Parse(Console.ReadLine());
            Console.WriteLine(new String('-', 50));
            var numbers = ReadInput(N);
            Console.Write("Numbers in reverce order: ");
            while (true)
            {
                Console.Write(numbers.Pop());
                if (numbers.Count == 0)
                {
                    break;
                }
                Console.Write(", ");
            }
            Console.WriteLine();
        }

        private static Stack<int> ReadInput(int n)
        {
            Stack<int> input = new Stack<int>();
            while (n != 0)
            {
                string line = Console.ReadLine();
                input.Push(int.Parse(line));
                n--;
            }
            return input;
        }
    }
}
