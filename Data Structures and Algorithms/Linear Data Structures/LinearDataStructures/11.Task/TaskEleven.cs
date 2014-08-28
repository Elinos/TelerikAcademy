using System;
using System.Linq;

namespace _11.Task
{
    class TaskEleven
    {
        static void Main(string[] args)
        {
            var ll = new MyLinkedList<int>();
            ll.AddFirst(1);
            ll.AddFirst(2);
            ll.AddFirst(3);
            ll.AddFirst(4);
            ll.AddFirst(5);
            foreach (var link in ll)
            {
                Console.WriteLine(link);
            }
        }
    }
}
