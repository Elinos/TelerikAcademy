using System;

class FindBitThree
{
    static void Main()
    {
        Console.Write("Enter an integer: ");
        int number = int.Parse(Console.ReadLine());
        // We need to use mask and bitwise "AND" to check the bit in position 3
        int mask = 1;
        mask = mask << 3; // move the "1" in the mask 3 positions to the left
        int bitNoThree = (number & mask) >> 3; // after we check the bit we need to move it to position 0
        string numberInBinary = Convert.ToString(number, 2);
        Console.WriteLine("The integer {0} is {1} in binary", number, numberInBinary.PadLeft(32, '0')); //we use PadLeft to represent all 32 positions of an Int32
        Console.WriteLine("The bit in position 3 of this integer is {0}", bitNoThree);
    }
}
