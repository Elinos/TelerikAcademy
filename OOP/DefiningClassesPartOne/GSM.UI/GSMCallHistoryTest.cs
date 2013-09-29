using System;
using System.Linq;
using GSMLib;

namespace GSMUI
{
    class GSMCallHistoryTest
    {
        // Tests the CallHistory functionality of the GSM class
        public static void Test()
        {
            GSM gsm = new GSM("Galaxy S IV", "Samsung");
            gsm.AddCall(new Call(DateTime.Now, "0876 321 434", 123));
            gsm.AddCall(new Call(DateTime.Now.AddHours(30), "+33 898 534 123", 432));
            gsm.AddCall(new Call(DateTime.Now.AddHours(5), "+359 234 534 233", 34));

            // Displays information about the calls and total price of the calls
            gsm.CallHistory.ForEach(Console.WriteLine);
            Console.WriteLine("{0:c2}", gsm.TotalCallCosts(0.37f));

            // Finds and deletes the longest call from the history
            gsm.DeleteCall(gsm.CallHistory.OrderByDescending(x => x.Duration).First());
            Console.WriteLine("{0:c2}", gsm.TotalCallCosts(0.37f));

            // Clears the call log and prints it
            gsm.ClearCallHistory();
            gsm.CallHistory.ForEach(Console.WriteLine);
        }
    }
}
