using System;
using System.Linq;

namespace Task1
{
    class Task1
    {
        static int[,] matrix;
        static bool[,] visited;
        static long currentMaxSum = 0;
        static int totalRows;
        static int totalCols;

        static void Main(string[] args)
        {
            var srtLocAsArray = Console.ReadLine().Split(' ');
            Point startingLocation = new Point(int.Parse(srtLocAsArray[0]), int.Parse(srtLocAsArray[1]));
            var rAndC = Console.ReadLine().Split(' ');
            totalRows = int.Parse(rAndC[0]);
            totalCols = int.Parse(rAndC[1]);
            matrix = new int[totalRows, totalCols];
            visited = new bool[totalRows, totalCols];

            for (int r = 0; r < totalRows; r++)
            {
                var line = Console.ReadLine().Split(' ');
                for (int c = 0; c < totalCols; c++)
                {
                    if (line[c] != "#")
                    {
                        matrix[r, c] = int.Parse(line[c]);
                    }
                    else
                    {
                        visited[r, c] = true;
                    }
                }
            }

            FindMax(startingLocation, 0, 0);
            Console.WriteLine(currentMaxSum);
        }

        private static void FindMax(Point startingLocation, long currentMax, int lastPoints)
        {
            if (!CheckIfInMatrix(startingLocation))
            {
                if (currentMax - lastPoints> currentMaxSum)
                {
                    currentMaxSum = currentMax - lastPoints;
                }
                return;
            }
            if (visited[startingLocation.Row, startingLocation.Col])
            {
                if (currentMax > currentMaxSum)
                {
                    currentMaxSum = currentMax;
                }
                return;
            }


            visited[startingLocation.Row, startingLocation.Col] = true;
            var points = matrix[startingLocation.Row, startingLocation.Col];
            currentMax += points;
            //go UP
            var upPos = GetNextPosition(startingLocation, 1, points);
            FindMax(upPos, currentMax, points);

            //go RIGTH
            var rightPos = GetNextPosition(startingLocation, 2, points);
            FindMax(rightPos, currentMax, points);


            //go DOWN
            var downPos = GetNextPosition(startingLocation, 3, points);
            FindMax(downPos, currentMax, points);


            //go LEFT
            var leftPos = GetNextPosition(startingLocation, 4, points);
            FindMax(leftPos, currentMax, points);

            visited[startingLocation.Row, startingLocation.Col] = false;

        }

        private static bool CheckIfInMatrix(Point nextPosition)
        {
            return nextPosition.Row >= 0 && nextPosition.Row < totalRows &&
                   nextPosition.Col >= 0 && nextPosition.Col < totalCols;
        }

        private static Point GetNextPosition(Point currentPosition, int direction, int points)
        {
            switch (direction)
            {
                case 1:
                    return new Point(currentPosition.Row - points, currentPosition.Col);
                case 2:
                    return new Point(currentPosition.Row, currentPosition.Col + points);
                case 3:
                    return new Point(currentPosition.Row + points, currentPosition.Col);
                case 4:
                    return new Point(currentPosition.Row, currentPosition.Col - points);
                default:
                    return new Point();
            }
        }

        struct Point
        {
            public Point(int row, int col)
                : this()
            {
                this.Row = row;
                this.Col = col;
            }
            public int Row { get; set; }
            public int Col { get; set; }
        }
    }
}
