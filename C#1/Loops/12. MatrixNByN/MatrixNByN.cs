using System;

class MatrixNByN
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                Console.Write((i + j - 1).ToString().PadRight(3));
            }
            Console.WriteLine();
        }
    }
}
