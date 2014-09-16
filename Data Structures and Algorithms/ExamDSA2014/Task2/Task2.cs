using System;
using System.Collections.Generic;
using System.Linq;

namespace Task
{
    class Program
    {
        static int numberOfShirts;
        static int numberOfGirs;
        static int[] shirts;
        static int[] arrForCombinations;
        static List<int[]> combinations = new List<int[]>();
        static List<char[]> variations = new List<char[]>();
        static int numberOfSkirts;
        static char[] skirts;
        static int[] arrForVariations;
        static bool[] used;
        static HashSet<string> results = new HashSet<string>();

        static void Main()
        {
            numberOfShirts = int.Parse(Console.ReadLine());
            shirts = new int[numberOfShirts];
            for (int i = 0; i < numberOfShirts; i++)
            {
                shirts[i] = i;
            }
            skirts = Console.ReadLine().ToCharArray();
            numberOfGirs = int.Parse(Console.ReadLine());
            arrForCombinations = new int[numberOfGirs];
            arrForVariations = new int[numberOfGirs];
            numberOfSkirts = skirts.Count();
            used = new bool[numberOfSkirts];
            GenerateCombinationsNoRepetitions(0, 0);
            GenerateVariationsNoRepetitions(0);
            for (int i = 0; i < combinations.Count; i++)
            {
                for (int j = 0; j < variations.Count; j++)
                {
                    string stringToAdd = "";
                    if (combinations[i].Length == 1 && variations[j].Length > 1)
                    {
                        stringToAdd = String.Format("{0}{1}-{2}{3}", combinations[i][0], variations[j][0], combinations[i][0], variations[j][1]);
                    }
                    else if (combinations[i].Length > 1 && variations[j].Length == 1)
                    {
                        stringToAdd = String.Format("{0}{1}-{2}{3}", combinations[i][0], variations[j][0], combinations[i][1], variations[j][0]);
                    }
                    else if (combinations[i].Length == 1 && variations[j].Length == 1)
                    {
                        stringToAdd = String.Format("{0}{1}-{2}{3}", combinations[i][0], variations[j][0], combinations[i][0], variations[j][0]);
                    }
                    else
                    {
                        stringToAdd = String.Format("{0}{1}-{2}{3}", combinations[i][0], variations[j][0], combinations[i][1], variations[j][1]);
                    }
                    results.Add(stringToAdd);

                }
            }
            var finalResults = results.OrderBy(x => x).ToList();
            Console.WriteLine(finalResults.Count());
            foreach (var result in finalResults)
            {
                Console.WriteLine(result);
            }
        }

        static void GenerateCombinationsNoRepetitions(int index, int start)
        {
            if (index >= numberOfGirs)
            {
                combinations.Add(arrForCombinations.ToArray());
            }
            else
            {
                for (int i = start; i < numberOfShirts; i++)
                {
                    arrForCombinations[index] = i;
                    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                }
            }
        }
        static void GenerateVariationsNoRepetitions(int index)
        {
            if (index >= numberOfGirs)
            {
                variations.Add(addVariations());
            }
            else
            {
                for (int i = 0; i < numberOfSkirts; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arrForVariations[index] = i;
                        GenerateVariationsNoRepetitions(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static char[] addVariations()
        {
            var toAdd = new char[arrForVariations.Length];
            for (int i = 0; i < arrForVariations.Length; i++)
            {
                toAdd[i] = skirts[arrForVariations[i]];
            }
            return toAdd;
        }

    }
}
