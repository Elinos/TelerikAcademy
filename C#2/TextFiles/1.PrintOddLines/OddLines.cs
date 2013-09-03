//Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        int n = 1;

        using (StreamReader input = new StreamReader("../../OddLines.cs"))
            for (string line; (line = input.ReadLine()) != null; n++)
                if (n % 2 == 1) Console.WriteLine(line);
    }
}
