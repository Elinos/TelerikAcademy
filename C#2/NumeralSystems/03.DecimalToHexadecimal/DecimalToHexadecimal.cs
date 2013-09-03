//Write a program to convert decimal numbers to their hexadecimal representation
using System;
using System.Text;

class DecimalToHexadecimal
{
    static void Main()
    {
        Console.Write("Please, enter decimal number to convert: ");
        int decimalNumber = int.Parse(Console.ReadLine());
        StringBuilder hexadecimalNumber = ConvertDecimalToHex(decimalNumber);
        Console.WriteLine("{0} = {1} in hexadecimal", decimalNumber, hexadecimalNumber.ToString());
    }
  
    private static StringBuilder ConvertDecimalToHex(int decimalNumber)
    {
        StringBuilder hexadecimalNumber = new StringBuilder();
        while (decimalNumber != 0)
        {
            int digit = decimalNumber % 16;
            switch (digit)
            {
                case 10:
                    hexadecimalNumber.Insert(0, "A");
                    break;
                case 11:
                    hexadecimalNumber.Insert(0, "B");
                    break;
                case 12:
                    hexadecimalNumber.Insert(0, "C");
                    break;
                case 13:
                    hexadecimalNumber.Insert(0, "D");
                    break;
                case 14:
                    hexadecimalNumber.Insert(0, "E");
                    break;
                case 15:
                    hexadecimalNumber.Insert(0, "F");
                    break;
                default:
                    hexadecimalNumber.Insert(0, digit);
                    break;
            }

            decimalNumber /= 16;
        }
        return hexadecimalNumber;
    }
}