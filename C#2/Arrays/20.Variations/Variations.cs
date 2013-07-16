//20. Write a program that reads two numbers N and 
//K and generates all the variations of K elements 
//from the set [1..N].
using System;

class Variations
{
    static void Gen01(int index, int n, int[] variations)
    {
        if (index == -1)
        {
            Print(variations);
        }
        else
        {
            for (int i = 1; i <= n; i++)
            {
                variations[index] = i;
                Gen01(index - 1, n, variations);
            }
        }
    }

    static void Print(int[] variations)
    {
        Console.WriteLine("[{0}]", String.Join(", ", variations));
    }

    static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        int k = int.Parse(Console.ReadLine());
        int[] variations = new int[k];
        Console.WriteLine("All the variations of {0} elements from the set [1..{1}]:", k, n);
        Gen01(k - 1, n, variations);
    }
}
