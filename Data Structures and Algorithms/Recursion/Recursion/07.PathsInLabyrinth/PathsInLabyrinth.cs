﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PathsInLabyrinth
{
    class PathsInLabyrinth
    {
        static char[,] lab = 
    {
        {' ', ' ', ' ', '*', ' ', ' ', ' '},
        {'*', '*', ' ', '*', ' ', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', '*', '*', '*', '*', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
    };

        static readonly List<Tuple<int, int>> path = new List<Tuple<int, int>>();

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
        }

        static void FindPathToExit(int row, int col)
        {
            if (!InRange(row, col))
            {
                // We are out of the labyrinth -> can't find a path
                return;
            }

            // Check if we have found the exit
            if (lab[row, col] == 'e')
            {
                PrintPath(row, col);
            }

            if (lab[row, col] != ' ')
            {
                // The current cell is not free -> can't find a path
                return;
            }

            // Temporary mark the current cell as visited to avoid cycles
            lab[row, col] = 's';
            path.Add(new Tuple<int, int>(row, col));

            // Invoke recursion the explore all possible directions
            FindPathToExit(row, col - 1); // left
            FindPathToExit(row - 1, col); // up
            FindPathToExit(row, col + 1); // right
            FindPathToExit(row + 1, col); // down

            // Mark back the current cell as free
            // Comment the below line to visit each cell at most once
            lab[row, col] = ' ';
            path.RemoveAt(path.Count - 1);
        }

        private static void PrintPath(int finalRow, int finalCol)
        {
            Console.Write("Found the exit: ");
            foreach (var cell in path)
            {
                Console.Write("({0},{1}) -> ", cell.Item1, cell.Item2);
            }
            Console.WriteLine("({0},{1})", finalRow, finalCol);
            Console.WriteLine();
        }

        static void Main()
        {
            FindAllPaths(2, 5, 4, 6);
        }

        private static void FindAllPaths(int startRow, int startCol, int endRow, int endCol)
        {
            if (lab[endRow, endCol] != '*')
            {
                lab[endRow, endCol] = 'e';
                if (lab[startRow, startCol] != '*')
                {
                    FindPathToExit(startRow, startCol);
                }
                else
                {
                    Console.WriteLine("There is obstacle at start position");
                }
            }
            else
            {
                Console.WriteLine("There is obstacle at end position");
            }
        }
    }
}
