using System;

class Program
{
    private static int currentMinDivisors = int.MaxValue;
    private static int result = 0;
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(arr);
        PermuteRep(arr, 0, arr.Length);
        Console.WriteLine(result);

    }

    static void PermuteRep(int[] arr, int start, int n)
    {
        SetResult(arr);

        for (int left = n - 2; left >= start; left--)
        {
            for (int right = left + 1; right < n; right++)
            {
                if (arr[left] != arr[right])
                {
                    Swap(ref arr[left], ref arr[right]);
                    PermuteRep(arr, left + 1, n);
                }
            }

            var firstElement = arr[left];
            for (int i = left; i < n - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[n - 1] = firstElement;
        }
    }

    static void SetResult<T>(T[] arr)
    {
        var currentNumberAsString = string.Join("", arr);
        result = CheckMinDivisors(int.Parse(currentNumberAsString));
    }

    private static int CheckMinDivisors(int number)
    {
        int currentDivisors = FindDivisors(number);
        if (currentDivisors <= currentMinDivisors)
        {
            if (currentDivisors == currentMinDivisors && number < result)
            {
                currentMinDivisors = currentDivisors;
                result = number;
            }
            else if (currentDivisors < currentMinDivisors)
            {
                currentMinDivisors = currentDivisors;
                result = number;
            }
        }
        return result;
    }

    private static int FindDivisors(int number)
    {
        int limit = number;
        int numberOfDivisors = 0;

        for (int i = 1; i < limit; ++i)
        {
            if (number % i == 0)
            {
                limit = number / i;
                if (limit != i)
                {
                    numberOfDivisors++;
                }
                numberOfDivisors++;
            }
        }

        return numberOfDivisors;
    }

    static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }
}