//7. Write a method that reverses the digits of given 
//decimal number. Example: 256 ‡ 652
using System;
using System.Linq;

class ReverseTheDigits
{
    static void Main()
    {
        Console.Write("Write a decimal number for convertion: ");
        decimal number = decimal.Parse(Console.ReadLine());
        Console.WriteLine(ReverseDigits(number));
    }
    private static decimal ReverseDigits(decimal number)
    {
        char[] reversed = number.ToString().ToCharArray();
        Array.Reverse(reversed);
        return decimal.Parse(new string(reversed));
    }
}

