using System;
using System.Linq;

namespace _01.BinaryPasswords
{
    class BinaryPasswords
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var unknownNumbers = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    unknownNumbers++;
                }
            }

            long result = 1;
            for (int i = 1; i <= unknownNumbers; i++)
            {
                result *= 2;
            }
            Console.WriteLine(result);
        }
    }
}
