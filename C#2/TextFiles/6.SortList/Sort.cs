//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file

﻿using System;
using System.IO;
using System.Collections.Generic;

class Sort
{
    static List<string> ReadLines()
    {
        List<string> lines = new List<string>();

        using (StreamReader input = new StreamReader("../../input.txt"))
            for (string line; (line = input.ReadLine()) != null; )
                lines.Add(line);

        return lines;
    }

    static void WriteLines(List<string> lines)
    {
        using (StreamWriter output = new StreamWriter("../../output.txt"))
            foreach (string line in lines)
                output.WriteLine(line);
    }

    static void Main()
    {
        List<string> lines = ReadLines();

        lines.Sort();

        WriteLines(lines);
    }
}
