/***************************************************************
 * 
 * 3. Write a program to check if in a given expression the 
 * brackets are put correctly.
 * Example of correct expression: ((a+b)/5-d).
 * Example of incorrect expression: )(a+b)).
 * 
 ***************************************************************/

using System;
using System.Linq;

class CheckExpressionBrackets
{
    static void Main()
    {
        string expression = Console.ReadLine();
        int difference = 0;
        foreach (char sybol in expression)
        {
            difference += CheckBracketDifference(sybol);
            if (difference < 0)
                break;        
        }
        if (difference == 0)
        {
            Console.WriteLine("Correct number of brackets!");
        }
        else
        {
            Console.WriteLine("Incorrect number of brackets!");
        }
    }
    static int CheckBracketDifference(char sybol)
    {
        if (sybol == '(')
            return 1;
        else if (sybol == ')')
            return -1;
        else
            return 0;
    }
}