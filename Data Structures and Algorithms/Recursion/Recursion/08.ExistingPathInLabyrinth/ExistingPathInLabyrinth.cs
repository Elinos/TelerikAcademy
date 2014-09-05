using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.ExistingPathInLabyrinth
{
    class ExistingPathInLabyrinth
    {
        static int size = 1000;
        static char[,] lab = new char[size, size];

        static void Main(string[] args)
        {
            FillLabirinth();
            SearchPath(lab, new Position(0, 0));
        }

        private static void FillLabirinth()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    lab[row, col] = ' ';
                }
            }
            
            lab[size - 1, size - 1] = 'e';
        }

        static bool InRange(Position position)
        {
            bool rowInRange = position.Row >= 0 && position.Row < lab.GetLength(0);
            bool colInRange = position.Col >= 0 && position.Col < lab.GetLength(1);
            return rowInRange && colInRange;
        }

        private static void SearchPath(char[,] arr, Position startPosition)
        {
            var Q = new Queue<Position>();
            lab[startPosition.Row, startPosition.Col] = '-';
            Q.Enqueue(startPosition);
            while (Q.Count != 0)
            {
                Position currentPosition = Q.Dequeue();
                for (int i = 1; i <= 4; i++)
                {
                    var nextPosition = GetNextPosition(currentPosition, i);
                    if (InRange(nextPosition) &&
                        (arr[nextPosition.Row, nextPosition.Col] == ' ' || arr[nextPosition.Row, nextPosition.Col] == 'e'))
                    {
                        if (arr[nextPosition.Row, nextPosition.Col] == 'e')
                        {
                            Console.WriteLine("Path found!");
                            return;
                        }
                        lab[nextPosition.Row, nextPosition.Col] = '-';
                        Q.Enqueue(nextPosition);
                    }
                }
            }
            Console.WriteLine("No path found!");
        }

        private static Position GetNextPosition(Position currentPosition, int i)
        {
            switch (i)
            {
                case 1: return new Position(currentPosition.Row - 1, currentPosition.Col);
                case 2: return new Position(currentPosition.Row, currentPosition.Col + 1);
                case 3: return new Position(currentPosition.Row + 1, currentPosition.Col);
                case 4: return new Position(currentPosition.Row, currentPosition.Col - 1);
                default: return null;
            }
        }
    }
}
