//Write a program to convert binary numbers to their decimal representation.

using System;

class BinaryToDecimal
{
    static void Main()
    {
        Console.Write("Please, enter binary number to convert: ");
        string binaryNumber = Console.ReadLine();
        int decimalNumber = 0;
        const int BinaryBase = 2;
        for (int index = 0; index < binaryNumber.Length; index++)
        {
            int element = int.Parse(binaryNumber[index].ToString());
            decimalNumber += element * (int)(Math.Pow(BinaryBase, binaryNumber.Length - 1 - index));
        }
        Console.WriteLine("{0} = {1} in decimal", binaryNumber, decimalNumber);
    }
}