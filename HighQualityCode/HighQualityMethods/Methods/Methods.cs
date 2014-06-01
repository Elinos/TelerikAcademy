namespace Methods
{
    using System;

    public class Methods
    {
        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(ConvertDigitToWord(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsFormatedNumber(1.3, "f");
            PrintAsFormatedNumber(0.75, "%");
            PrintAsFormatedNumber(2.30, "r");

            Point pointOne = new Point(3, -1);
            Point pointTwo = new Point(3, 2.5);

            bool horizontal = CheckLineBetweenTwoPointsIsHorizontal(pointOne, pointTwo);
            bool vertical = CheckLineBetweenTwoPointsIsVertical(pointOne, pointTwo);

            Console.WriteLine(CalcDistance(pointOne, pointTwo));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }

        private static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        private static string ConvertDigitToWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException("Invalid number!");
            }
        }

        private static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException();
            }

            if (elements.Length == 0)
            {
                throw new ArgumentOutOfRangeException("No elements were passed to the function");
            }

            int maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        private static void PrintAsFormatedNumber(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }

            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }

            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }

        private static double CalcDistance(Point pointOne, Point pointTwo)
        {
            double distance = Math.Sqrt((pointTwo.X - pointOne.X) * (pointTwo.X - pointOne.X) +
                                        (pointTwo.Y - pointOne.Y) * (pointTwo.Y - pointOne.Y));

            return distance;
        }

        private static bool CheckLineBetweenTwoPointsIsHorizontal(Point pointOne, Point pointTwo)
        {
            return pointOne.X == pointTwo.X;
        }

        private static bool CheckLineBetweenTwoPointsIsVertical(Point pointOne, Point pointTwo)
        {
            return pointOne.Y == pointTwo.Y;
        }
    }
}
