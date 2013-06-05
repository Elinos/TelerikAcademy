using System;

class IntDoubleOrString
{
    static void Main()
    {
        Console.Write("Choose what type of value you want to enter\n'1' for Integer, '2' for Double or '3' for String: ");
        byte userChoise = byte.Parse(Console.ReadLine());
        switch (userChoise)
        {
            case 1:
                Console.Write("Enter an integer: ");
                int valueInt = int.Parse(Console.ReadLine());
                Console.WriteLine("The value of your number increased with 1 is {0}", valueInt + 1);
                break;
            case 2:
                Console.Write("Enter a double: ");
                double valueDouble = double.Parse(Console.ReadLine());
                Console.WriteLine("The value of your number increased with 1 is {0}", valueDouble + 1);
                break;
            case 3:
                Console.Write("Enter your string: ");
                string valueString = Console.ReadLine();
                Console.WriteLine("Your string with '*' added in the end is {0}*", valueString);
                break;
            default:
                Console.WriteLine("Invalid input!");
                break;
        }
    }
}
