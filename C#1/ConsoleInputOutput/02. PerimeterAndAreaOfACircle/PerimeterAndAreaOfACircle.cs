using System;

class PerimeterAndAreaOfACircle
{
    static void Main()
    {
        Console.Write("Enter the radius of a circle: ");
        double radius = double.Parse(Console.ReadLine());
        double areaOfACircle = Math.PI * (radius * radius);
        double perimeterOfACircle = 2 * Math.PI * radius;
        Console.WriteLine("A circle with radius of {0} have perimeter of {1} and area of {2}", radius, perimeterOfACircle, areaOfACircle);
    }
}
