using System;

class FindTheBit
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        // We need to use mask and bitwise "AND" to check the bit in position n
        int mask = 1;
        Console.Write("Enter the position of the bit that you want to find: ");
        int bitPositionNoN = int.Parse(Console.ReadLine());
        mask = mask << bitPositionNoN; // move the "1" in the mask n positions to the left
        int bitNoN = (number & mask) >> bitPositionNoN; // after we check the bit we need to move it to position 0
        string numberInBinary = Convert.ToString(number, 2);
        Console.WriteLine("The integer {0} is {1} in binary", number, numberInBinary.PadLeft(32, '0')); //we use PadLeft to represent all 32 positions of an Int32
        Console.WriteLine("The bit in position {0} of this integer is {1}", bitPositionNoN, bitNoN);
    }
}
