using System;
using System.Linq;

class ZigZag
{
    static int n;
    static int k;

    static int[] arr;
    static bool[] used;
    static int count = 0;

    static void Main()
    {
        var nkAsString = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        n = nkAsString[0];
        k = nkAsString[1];
        if (k == 1)
        {
            Console.WriteLine(n);
        }
        else
        {
            arr = new int[k];
            used = new bool[n];
            GenerateVariationsNoRepetitions(0);
            Console.WriteLine(count);
        }
    }

    static void GenerateVariationsNoRepetitions(int index)
    {
        if (index >= k)
        {
            count++;
            return;
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                if (!used[i])
                {
                    if (index > 0 && CheckIfValid(i, index))
                    {
                        used[i] = true;
                        arr[index] = i;
                        GenerateVariationsNoRepetitions(index + 1);
                        used[i] = false;
                    }
                    else if (index == 0)
                    {
                        used[i] = true;
                        arr[index] = i;
                        GenerateVariationsNoRepetitions(index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }

    static bool CheckIfValid(int i, int index)
    {
        if (index % 2 == 1)
        {
            if (!(i > arr[index - 1]))
            {
                return false;
            }
        }
        else if (!(i < arr[index - 1]))
        {
            return false;
        }

        return true;
    }
}
