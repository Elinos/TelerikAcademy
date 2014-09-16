using System;
using System.Linq;

namespace Goro
{
    class Goro
    {
        static long maxPoints = 0;
        static int[] numbers = new int[3];

        static void Main()
        {
            for (int i = 0; i < 3; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var max = GetMax();
                maxPoints += max;
            }
            Console.WriteLine(maxPoints);
        }

        private static int GetMax()
        {
            var currentMax = numbers[0];
            var currentMaxIndex = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > currentMax)
                {
                    currentMax = numbers[i];
                    currentMaxIndex = i;
                }
            }
            if (numbers[currentMaxIndex] > 0)
            {
                numbers[currentMaxIndex]--;
            }
            return currentMax;
        }
    }
}
