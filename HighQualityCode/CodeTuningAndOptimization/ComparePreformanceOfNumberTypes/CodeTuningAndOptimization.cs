namespace _02.ComparePreformanceOfNumberTypes
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class ComparePreformanceOfNumberTypes
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

        public static void AdditionIntComparison(int startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue += 2;
            }
        }

        public static void AdditionLongComparison(long startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue += 2L;
            }
        }

        public static void AdditionFloatComparison(float startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue += 2.1F;
            }
        }

        public static void AdditionDoubleComparison(double startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue += 2.1;
            }
        }

        public static void AdditionDecimalComparison(decimal startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue += 2.1M;
            }
        }

        // Subtraction
        public static void SubtractionIntComparison(int startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue -= 2;
            }
        }

        public static void SubtractionLongComparison(long startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue -= 2L;
            }
        }

        public static void SubtractionFloatComparison(float startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue -= 2.1F;
            }
        }

        public static void SubtractionDoubleComparison(double startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue -= 2.1;
            }
        }

        public static void SubtractionDecimalComparison(decimal startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue -= 2.1M;
            }
        }

        // multiplication
        public static void MultiplicationIntComparison(int startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue = 5 * 2;
            }
        }

        public static void MultiplicationLongComparison(long startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue = 5L * 2L;
            }
        }

        public static void MultiplicationFloatComparison(float startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue = 5.3f * 2.1f;
            }
        }

        public static void MultiplicationDoubleComparison(double startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue = 5.3 * 2.1;
            }
        }

        public static void MultiplicationDecimalComparison(decimal startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue = 5.3M * 2.1M;
            }
        }

        // Division
        public static void DivisionIntComparison(int startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue = 100 / 2;
            }
        }

        public static void DivisionLongComparison(long startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue = 100L / 2L;
            }
        }

        public static void DivisionFloatComparison(float startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue = 100.6f / 2.3F;
            }
        }

        public static void DivisionDoubleComparison(double startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue = 100.6 / 2.3;
            }
        }

        public static void DivisionDecimalComparison(decimal startValue, int numberOfRepeating)
        {
            for (int i = 0; i < numberOfRepeating; i++)
            {
                startValue = 100.6M / 2.3M;
            }
        }

        public static void Main()
        {
            int repeatingNumber = 100000;
            DisplayPerformance(() => AdditionIntComparison(2, repeatingNumber), "Addition Int Comparison");
            DisplayPerformance(() => AdditionLongComparison(2L, repeatingNumber), "Addition Long Comparison");
            DisplayPerformance(() => AdditionFloatComparison(2.0F, repeatingNumber), "Addition Float Comparison");
            DisplayPerformance(() => AdditionDoubleComparison(2.1, repeatingNumber), "Addition Double Comparison");
            DisplayPerformance(() => AdditionDecimalComparison(2.1M, repeatingNumber), "Addition Decimal Comparison");

            DisplayPerformance(() => SubtractionIntComparison(repeatingNumber + 2, repeatingNumber), "Subtraction Int Comparison");
            DisplayPerformance(() => SubtractionLongComparison(repeatingNumber + 2L, repeatingNumber), "Subtraction Long Comparison");
            DisplayPerformance(() => SubtractionFloatComparison(repeatingNumber + 2.0F, repeatingNumber), "Subtraction Float Comparison");
            DisplayPerformance(() => SubtractionDoubleComparison(repeatingNumber + 2.1, repeatingNumber), "Subtraction Double Comparison");
            DisplayPerformance(() => SubtractionDecimalComparison(repeatingNumber + 2.1M, repeatingNumber), "Subtraction Decimal Comparison");

            DisplayPerformance(() => MultiplicationIntComparison(2, repeatingNumber), "Multiplication Int Comparison");
            DisplayPerformance(() => MultiplicationLongComparison(2L, repeatingNumber), "Multiplication Long Comparison");
            DisplayPerformance(() => MultiplicationFloatComparison(2.0F, repeatingNumber), "Multiplication Float Comparison");
            DisplayPerformance(() => MultiplicationDoubleComparison(2.1, repeatingNumber), "Multiplication Double Comparison");
            DisplayPerformance(() => MultiplicationDecimalComparison(2.1M, repeatingNumber), "Multiplication Decimal Comparison");

            DisplayPerformance(() => DivisionIntComparison(repeatingNumber + 2, repeatingNumber), "Division Int Comparison");
            DisplayPerformance(() => DivisionLongComparison(repeatingNumber + 2L, repeatingNumber), "Division Long Comparison");
            DisplayPerformance(() => DivisionFloatComparison(repeatingNumber + 2.0F, repeatingNumber), "Division Float Comparison");
            DisplayPerformance(() => DivisionDoubleComparison(repeatingNumber + 2.1, repeatingNumber), "Division Double Comparison");
            DisplayPerformance(() => DivisionDecimalComparison(repeatingNumber + 2.1M, repeatingNumber), "Division Decimal Comparison");
        }
    }
}