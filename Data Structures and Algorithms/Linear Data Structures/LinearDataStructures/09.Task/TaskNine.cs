using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Task
{
    class TaskNine
    {
        static void Main(string[] args)
        {
            int n = 2;
            int count = 50;
            PrintSequence(n, count);
        }

        private static void PrintSequence(int n, int count)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);
            while (count > 0)
            {
                int current = queue.Dequeue();
                Console.WriteLine(current);

                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);
                count--;
            }
        }
    }
}
