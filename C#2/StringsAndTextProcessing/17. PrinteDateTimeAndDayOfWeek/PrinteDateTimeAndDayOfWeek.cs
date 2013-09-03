/***************************************************************
 * 
 * 17. Write a program that reads a date and time given 
 * in the format: day.month.year 
 * hour:minute:second and prints the date and 
 * time after 6 hours and 30 minutes (in the same 
 * format) along with the day of week in Bulgarian.
 * 
 * 
 * 
 ***************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PrinteDateTimeAndDayOfWeek
{
    static void Main()
    {
        string[] input = File.ReadAllText("../../input.txt").Split(new char[] {'.', ':', ' '});
        int[] inputDT = input.Select(int.Parse).ToArray();
        DateTimeFormatInfo fmt = (new CultureInfo("bg-BG")).DateTimeFormat;
        DateTime dt = new DateTime(inputDT[2], inputDT[1], inputDT[0], inputDT[3], inputDT[4], inputDT[5]).AddHours(6).AddMinutes(30);
        Console.WriteLine("{0} {1}", fmt.GetDayName(dt.DayOfWeek), dt.ToString("dd.mm.yyyy hh:mm:ss"));
    }
}
