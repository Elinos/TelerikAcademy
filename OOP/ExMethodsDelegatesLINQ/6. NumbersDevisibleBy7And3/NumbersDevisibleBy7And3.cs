using System;
using System.Linq;

class NumbersDevisibleBy7And3
{
    static void Main()
    {
        int[] numbers = new int[100];
        for (int i = 0; i < 100; i++)
            numbers[i] = i + 1;

        //with lambda
        numbers.Where(x => x % 7 == 0 && x % 3 == 0).ToList().ForEach(Console.WriteLine);

        Console.WriteLine();

        PrintIntsDevisibleBy7And3(numbers);
    }
    //with LINQ
    public static void PrintIntsDevisibleBy7And3(int[] array)
    {
        (from number in array
         where number % 3 == 0 && number % 7 == 0
         select number).ToList().ForEach(Console.WriteLine);
    }
}

