using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

class NineGagNumbers
{
    static void Main()
    {
        if (File.Exists(@"..\..\input.txt"))
            Console.SetIn(new StreamReader(@"..\..\input.txt"));
        string rawNumber = Console.ReadLine().Trim();
        StringBuilder numberInGag = new StringBuilder();
        string[] nineGagNumbers = { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };
        string currentNumber = String.Empty;
        ulong number = 0;
        for (int i = 0; i < rawNumber.Length; i++)
        {
            char currentChar = rawNumber[i];
            currentNumber += currentChar;
            if (Array.IndexOf(nineGagNumbers, currentNumber) < 0)
            {
                continue;
            }
            else
            {
                numberInGag.Append(Array.IndexOf(nineGagNumbers, currentNumber));
                currentNumber = String.Empty;
            }
        }
        for (int i = numberInGag.Length - 1; i >= 0; i--)
        {
            ulong currentDigit = ulong.Parse(numberInGag[i].ToString());
            number += currentDigit * OnPower(9, numberInGag.Length - 1 - i);
        }
        Console.WriteLine(number);
    }
    static ulong OnPower(ulong number, int power)
    {
        ulong result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= number;
        }
        return result;
    }
}

