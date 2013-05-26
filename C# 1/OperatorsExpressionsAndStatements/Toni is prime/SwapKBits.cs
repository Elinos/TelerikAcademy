using System;

class SwapKBits
{
    static void Main()
    {
        Console.Write("Enter an unsigned integer number: ");
        uint number = uint.Parse(Console.ReadLine());
        Console.Write("Enter first bit position: ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("Enter second bit position: ");
        int q = int.Parse(Console.ReadLine());
        Console.Write("Enter number of bits to swap: ");
        int k = int.Parse(Console.ReadLine());

        if (Math.Abs(q - p) < k)
        {
            Console.WriteLine("Bits to swap are overlapping! You stupid whore!");
            return;
        }

        string bitStr = Convert.ToString(number, 2).PadLeft(32, '0');

        char[] newStr = new Char[32];
        newStr = bitStr.ToCharArray();
        for (int i = 0; i < k; i++)
        {
            newStr[31 - p - i] = bitStr[31 - q - i];
            newStr[31 - q - i] = bitStr[31 - p - i];
        }

        string new_bitStr = new String(newStr);
        uint new_num = Convert.ToUInt32(new_bitStr, 2);
        Console.WriteLine("The old number was: {0}", bitStr);
        Console.WriteLine("The new number is:  {0}", new_bitStr);
    }
}