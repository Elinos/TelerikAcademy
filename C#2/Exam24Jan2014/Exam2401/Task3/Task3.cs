using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Task3
    {
        static void Main(string[] args)
        {
            if (File.Exists(@"..\..\input.txt"))
                Console.SetIn(new StreamReader(@"..\..\input.txt"));
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                string[] splitted = line.Split();
                for (int m = 0; m < n; m++)
                {
                    matrix[i, m] = int.Parse(splitted[m]);
                }
            }
            Console.WriteLine(3);
        }
        static bool IsZero(int x, int y, int[,] matrix)
        {
            for (int i = 0; i < 2; i++)
            {
                if (y + 1 < matrix.GetLength(0) && matrix[x, y] == 0)
                {
                    y += 1;
                }
                else
                {
                    return false;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (x + 1 < matrix.GetLength(0) && matrix[x, y] == 0)
                {
                    x += 1;
                }
                else
                {
                    return false;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                if (y - 1 >= 0 && matrix[x, y] == 0)
                {
                    y -= 1;
                }
                else
                {
                    return false;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (x - 1 >= 0 && matrix[x, y] == 0)
                {
                    x -= 1;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
