using System;
using System.Globalization;

class FibonacciNumbers
{
    static void Main()
    {
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        nfi.NumberGroupSeparator = ",";
        nfi.NumberDecimalDigits = 0;
        Console.WriteLine("The first 100 members of the sequence of Fibonacci are:");
        decimal t1 = 0;
        decimal t2 = 1;
        decimal t3 = t1 + t2;

        Console.WriteLine("[1]: " + t1);
        Console.WriteLine("[2]: " + t2);
        Console.WriteLine("[3]: " + t3);

        for (decimal i = 4; i <= 100; i++)
        {
            t1 = t2;
            t2 = t3;
            t3 = t1 + t2;
            Console.WriteLine("[{0}]: {1:n}", i, t3.ToString("N", nfi));
        }
    }
}