using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    abstract class Shape
    {
        protected double width;
        protected double height;

        public abstract double CalculateSurface();

        public Shape(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
    }
}
