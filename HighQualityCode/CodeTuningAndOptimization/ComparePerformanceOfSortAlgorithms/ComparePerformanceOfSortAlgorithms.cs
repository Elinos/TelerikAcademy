namespace _04.ComparePerformanceOfSortAlgorithms
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    internal class ComparePerformanceOfSortAlgorithms
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

        public static void ArraySorting<T>(T[] array)
            where T : IComparable<T>
        {
            DisplayPerformance(() => InsertionSortAlgorithmPerformance(array), "InsertionSort Algorithm Performance");
            DisplayPerformance(() => SelectionSortAlgorithmPerformance(array), "SelectionSort Algorithm Performance");
            DisplayPerformance(() => QuicksortAlgorithmPerformance<T>(array), "Quicksort Algorithm Performance");
            DisplayPerformance(() => LambdaAlgorithmPerformance<T>(array), "Lambda Algorithm Performance");
            DisplayPerformance(() => LinqAlgorithmPerformance<T>(array), "Linq Algorithm Performance");
        }

        private static void InsertionSortAlgorithmPerformance<T>(T[] array)
            where T : IComparable<T>
        {
            T[] cloneArray = (T[])array.Clone();
            SortingAlgorithms.InsertionSort(cloneArray);
        }

        private static void SelectionSortAlgorithmPerformance<T>(T[] array)
            where T : IComparable<T>
        {
            T[] cloneArray = (T[])array.Clone();
            SortingAlgorithms.SelectionSort(cloneArray);
        }

        private static void QuicksortAlgorithmPerformance<T>(T[] array)
            where T : IComparable<T>
        {
            T[] cloneArray = (T[])array.Clone();
            SortingAlgorithms.Quicksort(cloneArray, 0, cloneArray.Length - 1);
        }

        private static void LambdaAlgorithmPerformance<T>(T[] array)
            where T : IComparable<T>
        {
            T[] cloneArray = (T[])array.Clone();
            SortingAlgorithms.LambdaSort(cloneArray);
        }

        private static void LinqAlgorithmPerformance<T>(T[] array)
            where T : IComparable<T>
        {
            T[] cloneArray = (T[])array.Clone();
            SortingAlgorithms.LinqSort(cloneArray);
        }

        private static void Main()
        {
            int arrayLength = 10000;
            int[] intsArray = GenerateRandomArrays.GetRandomIntArray(arrayLength);
            double[] doublesArray = GenerateRandomArrays.GetRandomDoubleArray(arrayLength);
            string[] stringsArray = GenerateRandomArrays.GetRandomStringArray(arrayLength, 100);

            Console.WriteLine("Unsorted arrays:");
            Console.WriteLine("Int Array:");
            ArraySorting<int>(intsArray);
            Console.WriteLine("Double Array:");
            ArraySorting<double>(doublesArray);
            Console.WriteLine("String Array:");
            ArraySorting<string>(stringsArray);

            Array.Sort(intsArray);
            Array.Sort(doublesArray);
            Array.Sort(stringsArray);

            Console.WriteLine();
            Console.WriteLine("Sorted arrays:");
            Console.WriteLine("Int Array:");
            ArraySorting<int>(intsArray);
            Console.WriteLine("Double Array:");
            ArraySorting<double>(doublesArray);
            Console.WriteLine("String Array:");
            ArraySorting<string>(stringsArray);

            intsArray = intsArray.OrderByDescending(x => x).ToArray();
            doublesArray = doublesArray.OrderByDescending(x => x).ToArray();
            stringsArray = stringsArray.OrderByDescending(x => x).ToArray();

            Console.WriteLine();
            Console.WriteLine("Reversed sorted arrays:");
            Console.WriteLine("Int Array:");
            ArraySorting<int>(intsArray);
            Console.WriteLine("Double Array:");
            ArraySorting<double>(doublesArray);
            Console.WriteLine("String Array:");
            ArraySorting<string>(stringsArray);
        }
    }
}
