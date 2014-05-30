namespace Methods
{
    public struct Point
    {
        public Point(double x, double y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }
    }
}
