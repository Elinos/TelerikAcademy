﻿//Write a program that concatenates two text files into another text file.

using System;
using System.IO;

class ConcatTwoFiles
{
    static void WriteToFile(StreamWriter output, string file)
    {
        using (StreamReader input = new StreamReader(file))
            for (string line; (line = input.ReadLine()) != null; )
                output.WriteLine(line);
    }

    static void Main()
    {
        string[] files = { "../../ConcatTwoFiles.cs", "../../ConcatTwoFiles.cs" };

        using (StreamWriter output = new StreamWriter("../../output.txt"))
            foreach (string file in files)
                WriteToFile(output, file);
    }
}
