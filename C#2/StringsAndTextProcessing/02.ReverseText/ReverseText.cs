/***************************************************************
 * 
 * 2. Write a program that reads a string, reverses it and 
 * prints the result at the console.
 * Example: "sample"  "elpmas".
 * 
 ***************************************************************/

using System;
using System.Linq;

class ReverseText
{
    static void Main()
    {
        Console.WriteLine(Console.ReadLine().Reverse().ToArray());
    }
}

