using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSMLib;

namespace GSMUI
{
    class GSMTest
    {
        static void Main()
        {
            GSM[] gsms =
            {
                new GSM("Galaxy S 4", "Samsung"),
                new GSM("Lumia 900", "Nokia"),
                new GSM("One", "HTC", 900, "Gosho", new Battery(), new Display())
            };

            foreach (var gsm in gsms)
            {
                Console.WriteLine(gsm);
            }
            Console.WriteLine(GSM.IPhone4S);

            Console.WriteLine(new string('-', 80));

            GSMCallHistoryTest.Test();
        }
    }
}
