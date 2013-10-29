using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomException
{
    class Test
    {
        static void Main(string[] args)
        {
            try
            {
                int test = 1000;
                int start = 1;
                int end = 100;

                if (test < start || test > end)
                    throw new InvalidRangeException<int>(start, end);
        
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine("{0} from {1} to {2}", e.Message, e.Start, e.End);
            }
            try
            {
                DateTime dttest = new DateTime(9999, 12, 31);
                DateTime dtstart = new DateTime(1980, 1, 1);
                DateTime dtend = new DateTime(2013, 12, 31);

                if (dttest < dtstart || dttest > dtend)
                {
                    throw new InvalidRangeException<DateTime>(dtstart, dtend);
                }
            }
            catch (InvalidRangeException<DateTime> d)
            {
                Console.WriteLine("{0} from {1} to {2}", d.Message, d.Start, d.End);
            }
            
        }
    }
}
