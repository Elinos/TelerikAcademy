using System;

class HexToDec
{
    static void Main()
    {
        Console.Write("Please, enter hexadecimal number to convert: ");
        string number = Console.ReadLine();
        char[] decArray = number.ToUpper().ToCharArray();
        Array.Reverse(decArray);
        double sum = 0;
        for (int i = 0; i < decArray.Length; i++)
        {
            int digit = 0;
            switch (decArray[i])
            {
                case 'A': digit = 10;
                    break;
                case 'B': digit = 11;
                    break;
                case 'C': digit = 12;
                    break;
                case 'D': digit = 13;
                    break;
                case 'E': digit = 14;
                    break;
                case 'F': digit = 15;
                    break;
                default: digit = int.Parse(decArray[i].ToString());
                    break;
            }
            for (int j = 0; j < i; j++)
            {
                digit = digit * 16;
            }

            sum += digit;
        }
        Console.WriteLine("{0} = {1} in decimal",number.ToUpper(), sum);
    }
}

