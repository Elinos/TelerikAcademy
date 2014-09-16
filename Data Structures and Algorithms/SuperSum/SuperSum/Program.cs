using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperSum
{
    class Program
    {
        static Dictionary<Tuple<int, int>, int> memo = new Dictionary<Tuple<int, int>, int>();

        static void Main(string[] args)
        {
            var lineArray = Console.ReadLine().Split(' ');
            var k = int.Parse(lineArray[0]);
            var n = int.Parse(lineArray[1]);
            Console.WriteLine(SuperSum(k, n));
        }

        private static int SuperSum(int k, int n)
        {
            var result = 0;
            if (k == 0)
            {
                result =  n;
                return result;
            }
            var forMemo = new Tuple<int, int>(k, n);

            for (int i = 1; i <= n; i++)
            {
                var current = new Tuple<int, int>(k - 1, i);
                if (memo.ContainsKey(current))
                {
                    result += memo[current];
                }
                else
                {
                    result += SuperSum(k - 1, i);
                }
            }
            if (!memo.ContainsKey(forMemo))
            {
                memo.Add(forMemo, result);
            }
            return result;
        }
    }
}
