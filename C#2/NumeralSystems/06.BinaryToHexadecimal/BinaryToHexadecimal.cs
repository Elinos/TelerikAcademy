//Write a program to convert binary numbers to hexadecimal numbers (directly).
using System;
using System.Text;

class BinaryToHexadecimal
{
    static void Main()
    {
        Console.Write("Please, enter binary number to convert: ");
        string binaryNumber = Console.ReadLine();
        StringBuilder hexadecimalNumber = ConvertBinaryToHex(binaryNumber);
        Console.WriteLine("{0} = {1} in hexadecimal", binaryNumber, hexadecimalNumber.ToString());
    }
  
    private static StringBuilder ConvertBinaryToHex(string binaryNumber)
    {
        StringBuilder hexadecimalNumber = new StringBuilder();
        int remainder = binaryNumber.Length % 4;
        if (remainder > 0) binaryNumber = (new string('0', 4 - remainder)) + binaryNumber;
        for (int index = 0; index < binaryNumber.Length; index += 4)
        {
            switch (binaryNumber.Substring(index, 4))
            {
                case "0000":
                    hexadecimalNumber.Append(0);
                    break;
                case "1000":
                    hexadecimalNumber.Append(8);
                    break;
                case "0001":
                    hexadecimalNumber.Append(1);
                    break;
                case "1001":
                    hexadecimalNumber.Append(9);
                    break;
                case "0010":
                    hexadecimalNumber.Append(2);
                    break;
                case "1010":
                    hexadecimalNumber.Append("A");
                    break;
                case "0011":
                    hexadecimalNumber.Append(3);
                    break;
                case "1011":
                    hexadecimalNumber.Append("B");
                    break;
                case "0100":
                    hexadecimalNumber.Append(4);
                    break;
                case "1100":
                    hexadecimalNumber.Append("C");
                    break;
                case "0101":
                    hexadecimalNumber.Append(5);
                    break;
                case "1101":
                    hexadecimalNumber.Append("D");
                    break;
                case "0110":
                    hexadecimalNumber.Append(6);
                    break;
                case "1110":
                    hexadecimalNumber.Append("E");
                    break;
                case "0111":
                    hexadecimalNumber.Append(7);
                    break;
                case "1111":
                    hexadecimalNumber.Append("F");
                    break;
                default:
                    break;
            }
        }
        return hexadecimalNumber;
    }
}

