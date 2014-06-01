using System;
using System.Text;

class PrintAsciiTable
{
    static void Main()
    {
        // Prints the whole ASCII table
        Console.WriteLine("--------------------");
        Console.WriteLine("| Unicode | Symbol |");
        Console.WriteLine("--------------------");

        int i;
        Console.OutputEncoding = Encoding.Unicode;
        for (i = 0; i <= 255; i++)
        {

            Console.WriteLine("| U+{0:x4} |    {1}", i, (char)i);
        }
    }
}
