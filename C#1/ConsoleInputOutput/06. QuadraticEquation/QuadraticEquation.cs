using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("Enter coefficients of the quadratic equation");
        Console.Write("Enter a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Enter c: ");
        int c = int.Parse(Console.ReadLine());


        double sqrtpart = b * b - 4 * a * c;
        double x, x1, x2;
        if (sqrtpart > 0)
        {
            x1 = (-b + System.Math.Sqrt(sqrtpart)) / (2 * a);
            x2 = (-b - System.Math.Sqrt(sqrtpart)) / (2 * a);
            Console.WriteLine("Two real solutions: {0:f2} and {1:f2}", x1, x2);
        }
        else if (sqrtpart < 0)
        {
            Console.WriteLine("No real solution!");
        }
        else
        {
            x = (-b + System.Math.Sqrt(sqrtpart)) / (2 * a);
            Console.WriteLine("One real solution: {0,8:f4}", x);
        }
    }
}
