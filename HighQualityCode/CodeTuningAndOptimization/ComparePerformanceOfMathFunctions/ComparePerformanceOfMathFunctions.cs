namespace _03.ComparePerformanceOfMathFunctions
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class ComparePerformanceOfMathFunctions
    {
        public static void DisplayPerformance(Action method, string methodName)
        {
            Console.WriteLine(methodName + " starting: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            method();
            timer.Stop();
            Console.WriteLine(methodName + " finished: " + timer.Elapsed.TotalMilliseconds + "ms");
        }

        public static void SquareRootPerformance(int numberOfRepeating)
        {
            double result;
            for (int i = 0; i < numberOfRepeating; i++)
            {
                result = Math.Sqrt(144);
            }
        }

        public static void NaturalLogarithmPerformance(int numberOfRepeating)
        {
            double result;
            for (int i = 0; i < numberOfRepeating; i++)
            {
                result = Math.Sqrt(144);
            }
        }

        public static void SinusPerformance(int numberOfRepeating)
        {
            double result;
            for (int i = 0; i < numberOfRepeating; i++)
            {
                result = Math.Sin(60);
            }
        }

        public static void Main()
        {
            int repeatingNumber = 100000;
            DisplayPerformance(() => SquareRootPerformance(repeatingNumber), "SquareRoot Performance");
            DisplayPerformance(() => NaturalLogarithmPerformance(repeatingNumber), "NaturalLogarithm Performance");
            DisplayPerformance(() => SinusPerformance(repeatingNumber), "Sinus Performance");
        }
    }
}