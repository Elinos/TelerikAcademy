using System;

class SwapBitsThreeToFiveWithTwentyFourToTwentySix
{
    static void Main()
    {
        Console.Write("Enter an unsigned integer number: ");
        uint number = uint.Parse(Console.ReadLine());
       
        string bitStr = Convert.ToString(number, 2).PadLeft(32, '0');

        char[] newStr = new Char[32];
        newStr = bitStr.ToCharArray();
        for (int i = 0; i < 3; i++)
        {
            newStr[31 - 3 - i] = bitStr[31 - 24 - i];
            newStr[31 - 24 - i] = bitStr[31 - 3 - i];
        }
        string new_bitStr = new String(newStr);
        uint new_num = Convert.ToUInt32(new_bitStr, 2);
        Console.WriteLine("The old number was: {0}", bitStr);
        Console.WriteLine("The new number is:  {0}", new_bitStr);
    }
}