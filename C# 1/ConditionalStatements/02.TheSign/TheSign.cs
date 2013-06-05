using System;

class TheSign
{
    static void Main()
    {
        int value = 0;
        int negativeCount = 0;
        bool isNotZero = true;
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter real number: ");
            value = int.Parse(Console.ReadLine());
            if (value == 0)
            {
                isNotZero = false;
            }
            else if (value < 0)
            {
                negativeCount++;
            }
        }
        if (isNotZero)
        {
            if (negativeCount % 2 == 0)
            {
                Console.WriteLine("The sign of the product is \"+\"");
            }
            else
            {
                Console.WriteLine("The sign of the product is \"-\"");
            } 
        }
        else
        {
            Console.WriteLine("The product will be 0");
        }
    }
}
