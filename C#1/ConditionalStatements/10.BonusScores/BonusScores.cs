using System;

class BonusScores
{
    static void Main()
    {
        Console.Write("Enter a digit from 1 to 9: ");
        int digit = int.Parse(Console.ReadLine());
        switch (digit)
        {
            case 1:
            case 2:
            case 3:
                Console.WriteLine("Your bonus score is {0}!", digit * 10);
                break;
            case 4:
            case 5:
            case 6:
                Console.WriteLine("Your bonus score is {0}!", digit * 100);
                break;
            case 7:
            case 8:
            case 9:
                Console.WriteLine("Your bonus score is {0}!", digit * 1000);
                break;
            default:
                Console.WriteLine("Invalid input!");
                break;
        }
    }
}
