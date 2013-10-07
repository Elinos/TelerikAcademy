using System;

namespace Path3D
{
    public struct Point3D
    {
        private int x;
        private int y;
        private int z;

        private static readonly Point3D pointO = new Point3D();

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int Z
        {
            get { return z; }
            set { z = value; }
        }

        public static Point3D PointO
        {
            get { return pointO; }
        }

        public Point3D(int x, int y, int z) : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return String.Format("X: {0}, Y: {1}, Z: {2}", X, Y, Z);
        }
    }
}
