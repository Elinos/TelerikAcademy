/***************************************************************
 * 
 * 16. Write a program that reads two dates in the 
 * format: day.month.year and calculates the 
 * number of days between them. Example:
 * 
 * Enter the first date: 27.02.2006
 * Enter the second date: 3.03.2006
 * Distance: 4 days
 * 
 ***************************************************************/

using System;
using System.IO;
using System.Linq;

class DistanceInDays
{
    static void Main()
    {
        string[] input = File.ReadAllLines("../../input.txt");
        int[] firstDate = input[0].Split('.').Reverse().Select(int.Parse).ToArray();
        int[] secondDate = input[1].Split('.').Reverse().Select(int.Parse).ToArray();
        TimeSpan diff = new DateTime(firstDate[0], firstDate[1], firstDate[2]) - new DateTime(firstDate[0], secondDate[1], secondDate[2]);
        Console.WriteLine("{0} days", Math.Abs(diff.Days));
    }
}
