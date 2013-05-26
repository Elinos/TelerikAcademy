using System;

class BitInPositionPofIntegerV
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
        bool bitIs1;
        if (bitNoN == 1)
        {
            bitIs1 = true;
            Console.WriteLine("The bit in position {0} of the integer {1} is 1! - {2}", bitPositionNoN, number, bitIs1);
        }
        else
        {
            bitIs1 = false;
            Console.WriteLine("The bit in position {0} of the integer {1} is NOT 1! - {2}", bitPositionNoN, number, bitIs1);
        }
    }
}
