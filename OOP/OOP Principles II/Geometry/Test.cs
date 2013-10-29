using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    class Test
    {
        static void Main(string[] args)
        {
            Shape[] shapes = { 
                new Triangle(1.5, 12),
                new Rectangle(5.32, 12.2),
                new Circle(1.5),
                new Triangle(0.5, 0.5)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0} surface: {1}", shape.GetType(), shape.CalculateSurface());
            }
        }
    }
}
