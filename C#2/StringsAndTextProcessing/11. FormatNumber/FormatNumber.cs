/***************************************************************
 * 
 * 11. Write a program that reads a number and prints it 
 * as a decimal number, hexadecimal number, 
 * percentage and in scientific notation. Format the 
 * output aligned right in 15 symbols.
 * 
 ***************************************************************/

using System;

class FormatNumber
{
    static void Main()
    {
        Console.WriteLine("{0,15:D}\r\n{0,15:X}\r\n{0,15:P}\r\n{0,15:E}", int.Parse(Console.ReadLine()));
    }
}
