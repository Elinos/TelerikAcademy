using System;
using System.Linq;

namespace _13.Task
{
    class TaskThirteen
    {
        static void Main(string[] args)
        {
            var queue = new LinkedQueue<int>();
            queue.Enqueue(1);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Count);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Count);
        }
    }
}
