using System;
using System.Linq;

namespace Lazyness
{
    class Lazyness
    {
        static void Main()
        {
            Console.ReadLine();
            var abAsArray = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int[] numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            Array.Sort(numbers, abAsArray[0], abAsArray[1] - abAsArray[0] + 1);
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}