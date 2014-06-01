using System;

class FindTheThirdDigit
{
    static void Main()
    {
        Console.Write("Enter an integer (minimum 3 digits): ");
        int thirdDigit = int.Parse(Console.ReadLine());
        thirdDigit = (thirdDigit / 100) % 10; // this will give us the 3rd digit
        if (thirdDigit == 7)
        {
            Console.WriteLine("The third digit (from right to left) is 7!!!");
        }
        else
        {
            Console.WriteLine("The third digit (from right to left) is NOT 7, it's {0}", thirdDigit);
        }        
    }
}
