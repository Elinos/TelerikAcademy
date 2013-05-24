using System;

class PointWithinACircle
{
    static void Main()
    {
        Console.Write("Enter x coordinate: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Enter y coordinate: ");
        int y = int.Parse(Console.ReadLine());
        int radius = 5;
        if ((x * x) + (y * y) < (radius * radius) )
        {
            Console.WriteLine("The point with cordinates {0},{1}\nwill be within a circle with cordinates 0,0 and radius {2}", x, y, radius);
        }
        else
        {
            Console.WriteLine("The point with cordinates {0},{1}\nwill NOT be within a circle with cordinates 0,0 and radius {2}", x, y, radius);
        }
    }
}
