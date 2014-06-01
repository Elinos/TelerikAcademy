using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int row = 0; row < n / 2; row++)
        {
            Console.Write(new string('.', ((n - 2) / 2) - row));
            Console.Write('#');
            Console.Write(new string('.', row * 2));
            Console.Write('#');
            Console.Write(new string('.', ((n - 2) / 2) - row));
            Console.WriteLine();
        }
        for (int row = 0; row < n / 4; row++)
        {
            Console.Write(new string('.', row));
            Console.Write('#');
            Console.Write(new string('.', (n - 2) - row * 2));
            Console.Write('#');
            Console.Write(new string('.', row));
            Console.WriteLine();
        }
        Console.WriteLine(new string('-', n));
        for (int row = 0; row < n / 2; row++)
        {
            Console.Write(new string('.', row));
            Console.Write(new string('\\', n / 2 - row));
            Console.Write(new string('/', n / 2 - row));
            Console.Write(new string('.', row));
            Console.WriteLine();
        }
    }
}