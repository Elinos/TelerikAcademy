using System;
using System.IO;
using System.Linq;

class ThreeInOne
{
    static void Main()
    {
        if (File.Exists(@"..\..\input.txt"))
            Console.SetIn(new StreamReader(@"..\..\input.txt"));
        //FirstTask
        FirstTask();

        //SecondTask
        SecondTask();
        

        //ThirdTask
        ThirdTask();
        
    }

    private static void ThirdTask()
    {
        string temp = Console.ReadLine();
        int[] both = temp.Split().Select(int.Parse).ToArray();
        int[] current = both.Take(3).ToArray();
        int[] target = both.Skip(3).Take(3).ToArray();
        const int GOLD = 0;
        const int SILVER = 1;
        const int BRONZE = 2;
        int operations = 0;

        while (true)
        {
            if (current[GOLD] >= target[GOLD] &&
                    current[SILVER] >= target[SILVER] &&
                    current[BRONZE] >= target[BRONZE])
            {
                Console.WriteLine(operations);
                return;
            }
            while (current[SILVER] > target[SILVER])
            {
                if (target[GOLD] > current[GOLD])
                {
                    if (current[SILVER] - target[SILVER] >= 11)
                    {
                        current[SILVER] -= 11;
                        current[GOLD]++;
                        operations++;
                    }
                    else if (current[BRONZE] - target[BRONZE] >= 11)
                    {
                        current[BRONZE] -= 11;
                        current[SILVER]++;
                        operations++;
                    }
                    else
                    {
                        Console.WriteLine(-1);
                        return;
                    }

                }
                else if (target[BRONZE] > current[BRONZE])
                {
                    current[SILVER]--;
                    current[BRONZE] += 9;
                    operations++;
                }
                else
                {
                    Console.WriteLine(operations);
                    return;
                }

            }
            while (current[SILVER] < target[SILVER])
            {
                if (current[GOLD] > target[GOLD])
                {
                    current[GOLD]--;
                    current[SILVER] += 9;
                    operations++;
                }
                else if (current[BRONZE] - target[BRONZE] >= 11)
                {
                    current[SILVER]++;
                    current[BRONZE] -= 11;
                    operations++;
                }
                else
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
            if (current[GOLD] < target[GOLD])
            {
                if (current[BRONZE] - target[BRONZE] >= 11)
                {
                    current[SILVER]++;
                    current[BRONZE] -= 11;
                    operations++;
                }
                else
                {
                    Console.WriteLine(-1);
                    return;
                }

            }

            if (current[BRONZE] < target[BRONZE])
            {
                if (current[GOLD] > target[GOLD])
                {
                    current[GOLD]--;
                    current[SILVER] += 9;
                    operations++;
                }
                else
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
        }
    }

    private static void SecondTask()
    {
        //SecondTask
        int[] cakes = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
        int[] sortedCakes = cakes.OrderByDescending(x => x).ToArray();
        int myBites = 0;
        int friendsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < sortedCakes.Length; i += friendsCount + 1)
        {
            myBites += sortedCakes[i];
        }
        Console.WriteLine(myBites);
    }

    private static void FirstTask()
    {
        //FirstTask
        int[] points = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
        int max = -1;
        for (int i = 0; i < points.Length; i++)
        {
            if (points[i] <= 21 && max < points[i])
            {
                max = points[i];
            }
        }
        if (max > 0 && points.Count(x => x == max) == 1)
        {
            Console.WriteLine(Array.IndexOf(points, max));
        }
        else
        {
            Console.WriteLine(-1);
        }
    }
}

