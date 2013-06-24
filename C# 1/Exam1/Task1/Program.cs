using System;
using System.Globalization;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int N05 = int.Parse(Console.ReadLine());
        int N10 = int.Parse(Console.ReadLine());
        int N20 = int.Parse(Console.ReadLine());
        int N50 = int.Parse(Console.ReadLine());
        int N100 = int.Parse(Console.ReadLine());
        decimal A = decimal.Parse(Console.ReadLine());
        decimal P = decimal.Parse(Console.ReadLine());

        decimal sumOfMachineCoins = (N05 * 0.05m) + (N10 * 0.10m) + (N20 * 0.20m) + (N50 * 0.50m) + (N100 * 1m);
        if (A - P < 0)
        {
            Console.WriteLine("More {0:f2}", Math.Abs(A - P));
        }
        else if (A - P >= 0)
        {
            if ((A - P) <= sumOfMachineCoins)
            {
                Console.WriteLine("Yes {0:f2}", sumOfMachineCoins - (A - P));
            }
            else
            {
                Console.WriteLine("No {0:f2}", Math.Abs(sumOfMachineCoins - (A - P)));
            }
        }
    }
}