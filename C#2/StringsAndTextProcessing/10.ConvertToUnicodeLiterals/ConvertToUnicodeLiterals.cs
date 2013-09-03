/***************************************************************
 * 
 * 10. Write a program that converts a string to a 
 * sequence of C# Unicode character literals. Use 
 * format strings. Sample input:
 * 
 * Hi!
 * 
 * 		Expected output:
 * 		
 * \u0048\u0069\u0021
 * 
 ***************************************************************/

using System;
using System.Text;

class ConvertToUnicodeLiterals
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        foreach (char symbol in Console.ReadLine())    
            sb.Append(String.Format("\\u{0:X4}", (int)symbol));      
        Console.WriteLine(sb);
    }
}

