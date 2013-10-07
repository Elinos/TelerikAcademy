using System;

namespace Path3D
{
    public static class Distance3D
    {
        public static double GetDistance(Point3D p1, Point3D p2)
        {
            int deltaX = p1.X - p2.X;
            int deltaY = p1.Y - p2.Y;
            int deltaZ = p1.Z - p2.Z;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        }
    }
}
