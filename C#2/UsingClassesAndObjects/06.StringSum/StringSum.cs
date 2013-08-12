using System;

class StringSum
{
    static void Main()
    {
        string stringToSum = "43 68 9 23 318";        
        Console.WriteLine("The sum of the numbers {0} is : {1}", stringToSum, SumNumbersOfString(stringToSum));
    }
  
    private static int SumNumbersOfString(string stringToSum)
    {
        string[] splittedString = stringToSum.Split();
        int sum = 0;
        foreach (var number in splittedString)
            sum += int.Parse(number);
        return sum;
    }
}

