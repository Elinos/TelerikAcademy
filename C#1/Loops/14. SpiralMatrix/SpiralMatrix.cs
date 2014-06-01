using System;

class SpiralMatrix
{
    static void Main()
    {
        Console.Write("Enter matrix size: ");
        int n = int.Parse(Console.ReadLine()); ;
        int[,] matrix = new int[n, n];
        string direction = "right";

        int row = 0;
        int col = 0;

        for (int i = 1; i <= n * n; i++)
        {
            matrix[row, col] = i;

            if (direction == "right")
            {
                if ((col + 1 != n) && (matrix[row, col + 1] == 0))
                {
                    col++;
                }
                else
                {
                    direction = "down";
                    row++;
                }
            }
            else if (direction == "down")
            {
                if ((row + 1 != n) && (matrix[row + 1, col] == 0))
                {
                    row++;
                }
                else
                {
                    direction = "left";
                    col--;
                }
            }
            else if (direction == "left")
            {
                if ((col > 0) && (matrix[row, col - 1] == 0))
                {
                    col--;
                }
                else
                {
                    direction = "up";
                    row--;
                }
            }
            else if (direction == "up")
            {
                if ((row > 0) && (matrix[row - 1, col] == 0))
                {
                    row--;
                }
                else
                {
                    direction = "right";
                    col++;
                }
            }

        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j].ToString().PadRight(4));
            }
            if (n < 20)
            {
                Console.WriteLine();
            }
        }
    }
}
