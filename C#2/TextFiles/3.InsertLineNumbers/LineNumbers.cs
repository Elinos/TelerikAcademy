//Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file.

using System;
using System.IO;

class LineNumbers
{
    static void Main()
    {
        int n = 1;

        using (StreamReader input = new StreamReader("../../LineNumbers.cs"))
        using (StreamWriter output = new StreamWriter("../../output.txt"))
            for (string line; (line = input.ReadLine()) != null; n++)
                output.WriteLine("{0} - {1}", n, line);
    }
}
