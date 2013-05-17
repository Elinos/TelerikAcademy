using System;

class IsoscelesTriangle
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        char copyrightSymbol = '\u00A9';
        // Print isosceles triangle with nine © symbols
        Console.WriteLine("{0}\n{0}{0}\n{0}{0}{0}\n{0}{0}\n{0}", copyrightSymbol);
    }
}

