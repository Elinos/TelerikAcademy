using System;

class TrapezoidsArea
{
    static void Main()
    {
        Console.Write("Enter the side \"a\" of a trapezoid: ");
        int sideA = int.Parse(Console.ReadLine());
        Console.Write("Enter the side \"b\" of a trapezoid: ");
        int sideB = int.Parse(Console.ReadLine());
        Console.Write("Enter the height \"h\" of a trapezoid: ");
        int heightH = int.Parse(Console.ReadLine());
        float areaOfTrapezoid = ((sideA + sideB) * heightH) / 2.0f;
        Console.WriteLine("The area of a trapezoid with sides {0} and {1} and hegith {2} is {3}", sideA, sideB, heightH, areaOfTrapezoid );
    }
}
