//3. Write a method that returns the last digit of given 
//integer as an English word. Examples: 512 ‡ 
//"two", 1024 ‡ "four", 12309 ‡ "nine".
using System;

class LastDigit
{
    static void Main()
    {
        int number = 2347;
        Console.WriteLine("The last digit is [{0}]", FindLastDigit(number));
    }
  
    private static string FindLastDigit(int number)
    {
        int lastDigit = number % 10;
        string lastDigitToString = String.Empty;
        switch (lastDigit)
        {
            case 0: lastDigitToString = "zero";
                break;
            case 1: lastDigitToString = "one";
                break;
            case 2: lastDigitToString = "two";
                break;
            case 3: lastDigitToString = "three";
                break;
            case 4: lastDigitToString = "four";
                break;
            case 5: lastDigitToString = "five";
                break;
            case 6: lastDigitToString = "six";
                break;
            case 7: lastDigitToString = "seven";
                break;
            case 8: lastDigitToString = "eight";
                break;
            case 9: lastDigitToString = "nine";
                break;
            default: Console.WriteLine("Error");
                break;
        }
        return lastDigitToString;
    }
}

