using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            long input = long.Parse(Console.ReadLine());
            if (input != -1)
            {
                int[] number = new int[32];
                for (int i = 0; i < 32; i++)
                {
                    number[i] = (int)((input >> i) & 1);
                }
                int start = 32;
                int end = -1;
                for (int i = 0; i < 32; i++)
                {
                    if (number[i] == 1)
                    {
                        start = i;
                        break;
                    }
                }
                for (int i = 31; i >= 0; i--)
                {
                    if (number[i] == 1)
                    {
                        end = i;
                        break;
                    }
                }
                int realNumber = 0;
                for (int i = start; i <= end; i++)
                {
                    if (number[i] == 0)
                    {
                        realNumber += (int)Math.Pow(2, i);
                    }
                }
                Console.WriteLine(realNumber);
            }
            else break;
        }
    }
}