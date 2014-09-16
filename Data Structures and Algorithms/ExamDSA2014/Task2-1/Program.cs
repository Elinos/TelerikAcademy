using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1
{
    class Program
    {
        const int n2 = 4;
        const int k2 = 2;
        static char[] objects2 = new char[n2] 
	{
		'b', 'a', 'c', 'a'
	};
        static int[] arr2 = new int[k2];
        static bool[] used = new bool[n2];
        static void Main()
        {
            
        }

        
        static void GenerateVariationsNoRepetitions(int index)
        {
            if (index >= k2)
            {
                PrintVariations();
            }
            else
            {
                for (int i = 0; i < n2; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr2[index] = i;
                        GenerateVariationsNoRepetitions(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        static void PrintVariations()
        {
            Console.Write("(" + String.Join(", ", arr2) + ") --> ( ");
            for (int i = 0; i < arr2.Length; i++)
            {
                Console.Write(objects2[arr2[i]] + " ");
            }
            Console.WriteLine(")");
        }
    }
}
