using System;

class SetTheBit
{
    static void Main()
    {
        Console.Write("Enter the number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Enter the new bit value (0/1): ");
        byte newBitValue = byte.Parse(Console.ReadLine());
        Console.Write("Enter the position of the new bit: ");
        int position = int.Parse(Console.ReadLine());
        int mask;
        int newNumber;
        if (newBitValue == 0)
        {
            mask = ~(1 << position);
            newNumber = number & mask;
        }
        else
        {
            mask = 1 << position;
            newNumber = number | mask;
        }
        Console.WriteLine("The old number was: {0}", Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.WriteLine("The new number is:  {0}", Convert.ToString(newNumber, 2).PadLeft(32, '0'));
    }
}
