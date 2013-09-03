/***************************************************************
 * 
 * 24. Write a program that reads a list of words, 
 * separated by spaces and prints the list in an 
 * alphabetical order.
 * 
 ***************************************************************/

using System;
using System.Linq;

class PrintListInOrder
{
    static void Main()
    {
        Console.WriteLine(String.Join(" ", Console.ReadLine().Split(' ').OrderBy(x => x)));
    }
}
