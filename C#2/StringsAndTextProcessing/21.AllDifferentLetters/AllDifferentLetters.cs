/***************************************************************
 * 
 * 21. Write a program that reads a string from the   
 * console and prints all different letters in the string 
 * along with information how many times each 
 * letter is found. 
 *
 ***************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AllDifferentLetters
{
    static void Main()
    {
        string input = Console.ReadLine();
        int[] symbolsCount = new int['z' + 1];
        foreach (char symbol in input)
            symbolsCount[(int)symbol]++;
        for (int i = 0; i < symbolsCount.Length; i++)
        {
            if (symbolsCount[i] != 0)
                Console.WriteLine("{0} - {1}", (char)i, symbolsCount[i]);
        }
    }
}

