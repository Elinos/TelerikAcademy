using System;
using System.Text;

class SignedIntegerToBinary
{
    static void Main()
    {
        Console.Write("Please, enter 16-bit signed integer number to convert: ");
        short inputNumber = short.Parse(Console.ReadLine());

        if (inputNumber >= 0)
        {
            StringBuilder convertedNumber = new StringBuilder();
            convertedNumber.AppendFormat(DecimalToBinary.ConvertDecimalToBinary(inputNumber).ToString());
            Console.WriteLine("{0} = {1} in binary", inputNumber, convertedNumber.ToString());
        }
        else
        {
            int numberToConvert = short.MaxValue + 1 + inputNumber;
            StringBuilder convertedNumber = new StringBuilder();
            convertedNumber.Append(1);
            convertedNumber.AppendFormat(DecimalToBinary.ConvertDecimalToBinary(numberToConvert).ToString().PadLeft(15, '0'));
            Console.WriteLine("{0} = {1} in binary", inputNumber, convertedNumber);
        }
    }
}

