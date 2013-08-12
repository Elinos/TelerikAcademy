using System;
using System.Linq;

class WorkingDays
{
    static void Main()
    {
        Console.Write("Enter the final date YYYY/MM/DD: ");
        DateTime finalDate = DateTime.Parse(Console.ReadLine());
        DateTime[] holidays =
        {
           new DateTime(2013, 01, 1),
           new DateTime(2013, 03, 03),
           new DateTime(2013, 05, 01),
           new DateTime(2013, 05, 24),
           new DateTime(2013, 09, 06),
           new DateTime(2013, 09, 22),
           new DateTime(2013, 11, 01),
           new DateTime(2013, 12, 24),
           new DateTime(2013, 12, 25),
           new DateTime(2013, 12, 26),
           new DateTime(2013, 12, 31)
        };
        Console.WriteLine("There are {0} working days between today and {1}", GetWorkingDays(finalDate, holidays), finalDate);
    }
    public static int GetWorkingDays(DateTime finalDate, DateTime[] holidays)
    {
        var totalDays = 0;
        for (var date = DateTime.Today; date <= finalDate; date = date.AddDays(1))
        {
            if (date.DayOfWeek != DayOfWeek.Saturday
                && date.DayOfWeek != DayOfWeek.Sunday
                && !holidays.Contains(date))
                totalDays++;
        }

        return totalDays;
    }
}

