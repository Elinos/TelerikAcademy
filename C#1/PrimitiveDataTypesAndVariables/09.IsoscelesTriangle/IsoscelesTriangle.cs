using System;

class PrintTriangle
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;

        char symbol = '\u00a9';
        Console.Write("Enter the number of rows for the isosceles triangle: ");
        int rowNumber = int.Parse(Console.ReadLine());
        for (int i = 1; i <= rowNumber; i++)
        {
            Console.Write(new string(' ', rowNumber - i));
            Console.Write(new string(symbol, i * 2 - 1));
            Console.WriteLine();
        }
    }
}