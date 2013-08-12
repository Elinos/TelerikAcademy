using System;

class DayOfTheWeek
{
    static void Main()
    {
        string dayOfTheWeek = DateTime.Today.DayOfWeek.ToString();
        Console.WriteLine("Today is {0}", dayOfTheWeek);
    }
}

