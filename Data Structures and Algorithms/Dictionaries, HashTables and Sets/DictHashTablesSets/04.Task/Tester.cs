using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Task
{
    class Tester
    {
        public static void Main()
        {
            var myhashtable = new MyHashTable<int, string>();

            myhashtable.Add(3, "ar");

            myhashtable[2] = "asd";

            var indexCheck = myhashtable[2];

            Console.WriteLine("toString:");
            Console.WriteLine(myhashtable);

            Console.WriteLine("indexer:");
            Console.WriteLine(myhashtable[2]);
            Console.WriteLine(indexCheck);

            Console.WriteLine("keys:");
            var keysChecker = myhashtable.Keys;

            foreach (var key in keysChecker)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine("count:");
            Console.WriteLine(myhashtable.Count);
            Console.WriteLine("remove:");
            myhashtable.Remove(4);

            Console.WriteLine(myhashtable[2]);

            myhashtable.Remove(2);

            Console.WriteLine(myhashtable[2]);
            Console.WriteLine("count:");
            Console.WriteLine(myhashtable.Count);

            string res;
            var findChecker = myhashtable.Find(3, out res);
            Console.WriteLine("Find value by key 3:");
            Console.WriteLine(res);
            Console.WriteLine(findChecker);

            Console.WriteLine(myhashtable);
            Console.WriteLine("clear");
            myhashtable.Clear();
            Console.WriteLine(myhashtable);
            Console.WriteLine("----");
            Console.WriteLine("resize");

            for (int i = 0; i < 100; i++)
            {
                myhashtable.Add(i, i.ToString());
            }

            Console.WriteLine(myhashtable);
        }
    }
}
