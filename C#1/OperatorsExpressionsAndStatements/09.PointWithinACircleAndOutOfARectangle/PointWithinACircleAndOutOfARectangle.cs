using System;

class PointWithinACircleAndOutOfARectangle
{
    static void Main()
    {
        Console.Write("Enter x coordinate: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Enter y coordinate: ");
        int y = int.Parse(Console.ReadLine());
        int radius = 3;
        if ((x - 1) * (x - 1) + (y - 1) * (y - 1) < radius * radius)
        {
            Console.WriteLine("The point with cordinates {0},{1}\nwill be within the circle K((1,1), 3)!", x, y);
        }
        else
        {
            Console.WriteLine("The point with cordinates {0},{1}\nwill NOT be within the circle K((1,1), 3)!", x, y);
        }
        if ((x >= -1) && (x <= 5) && (y <= 1) && (y >= -1)) //the coordinates of the rectangle are (1, -1); (5, 1); (-1, -1); (5, -1)
        {
            Console.WriteLine("The point with cordinates {0},{1}\nwill be within the rectangle R(top=1, left=-1, wight=6, height=2)!", x, y);
        }
        else
        {
            Console.WriteLine("The point with cordinates {0},{1}\nwill NOT be within the rectangle R(top=1, left=-1, wight=6, height=2)!", x, y);
        }

    }
}
