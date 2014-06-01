using System;

class PrintFirstTenMembers
{
    static void Main()
    {
        for (int i = 2; i < 12; i++)
        {
            Console.Write(i * Math.Pow(-1, i) + " ");
        }
        Console.WriteLine();
    }
}

