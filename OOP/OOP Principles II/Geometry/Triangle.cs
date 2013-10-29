using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    class Triangle : Shape
    {
        public Triangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return this.width * this.height / 2;
        }
    }
}
