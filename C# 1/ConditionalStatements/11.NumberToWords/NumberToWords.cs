using System;
using System.Text;

class NumberToWords
{
    static void Main()
    {
        Console.Write("Enter a number in the range [0-999]: ");
        int number = int.Parse(Console.ReadLine());
        int hundreds = number / 100;
        int tens = (number % 100) / 10;
        int ones = number % 10;

        StringBuilder numberWithWords = new StringBuilder();

        string[] words0 = { "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
        string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
        string[] words2 = { "", "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };

        if (hundreds > 0)
        {
            numberWithWords.Append(words0[hundreds - 1] + "Hundred ");
        }
        if (tens > 1)
        {
            if (ones == 0)
            {
                numberWithWords.Append("and ");
            }
            numberWithWords.Append(words2[tens - 1]);
            if (ones > 0)
            {
                numberWithWords.Append(words0[ones - 1]);
            }
        }
        else if (tens == 1)
        {
            if (hundreds > 0)
            {
                numberWithWords.Append("and ");
            }
            numberWithWords.Append(words1[ones]);
        }
        else
        {
            if (hundreds > 0)
            {
                if (ones > 0)
                {
                    numberWithWords.Append("and " + words0[ones - 1]);
                }
            }
            else
            {
                numberWithWords.Append(words0[ones - 1]);
            }
        }
        Console.WriteLine(numberWithWords.ToString().TrimEnd());
    }
}
