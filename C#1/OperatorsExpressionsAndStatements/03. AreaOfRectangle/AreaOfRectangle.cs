using System;

class AreaOfRectangle
{
    static void Main()
    {
        Console.Write("Enter the width of a rectangle: ");
        int width = int.Parse(Console.ReadLine());
        Console.Write("Enter the height of a rectangle: ");
        int height = int.Parse(Console.ReadLine());
        Console.WriteLine("The area of a rectangle with width = {0} and height = {1} is {2}", width, height, width * height);
    }
}
