using System;

class RandomNumbers
{
    static void Main()
    {
        Random rng = new Random();
        for (int i = 0; i < 10; i++)
            Console.WriteLine(rng.Next(100, 201));
    }
}

