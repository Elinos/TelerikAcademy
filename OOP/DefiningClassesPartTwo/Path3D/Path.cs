using System;
using System.Collections.Generic;

namespace Path3D
{
    public class Path
    {
        private List<Point3D> points = new List<Point3D>();

        public Path(params Point3D[] points)
        {
            foreach (Point3D point in points)
            {
                this.points.Add(point);
            }
        }

        public void AddPoint(Point3D point)
        {
            points.Add(point);
        }

        public override string ToString()
        {
            return String.Join("; ", points);
        }
    }
}
