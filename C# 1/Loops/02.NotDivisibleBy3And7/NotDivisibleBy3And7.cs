using System;

class NotDivisibleBy3And7
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            if (i % 21 != 0)
            {
                Console.WriteLine(i);
            }        
        }
    }
}
