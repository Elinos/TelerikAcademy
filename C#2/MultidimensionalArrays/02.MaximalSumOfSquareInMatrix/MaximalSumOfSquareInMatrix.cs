//Write a program that reads a rectangular matrix of size N x M
//and finds in it the square 3 x 3 that has maximal sum of its elements.
using System;

class MaximalSumOfSquareInMatrix
{
    static void Main()
    {
        //Hardcoded matrix
        int[,] matrix = new int[,] 
        {
        {1, 9, 9 ,9, 5, 6, -7, 8},
        {8, 9, 9, 9, -1, 3, 5, 0},
        {4, 9, 9, 9, 2, -3, 4, -9}
        };
        FindMaxSquare(matrix);
    }

    private static void FindMaxSquare(int[,] matrix)
    {
        int maxSum = int.MinValue;
        int maxRow = 0;
        int maxCol = 0;
        for (int row = 1; row < matrix.GetUpperBound(0); row++)
        {
            for (int col = 1; col < matrix.GetUpperBound(1); col++)
            {
                if (SumOfSquare(matrix, row, col) > maxSum)
                {
                    maxSum = SumOfSquare(matrix, row, col);
                    maxRow = row;
                    maxCol = col;
                }
            }
        }
        PrintMaxMatrix(matrix, maxRow, maxCol);
    }

    private static void PrintMaxMatrix(int[,] matrix, int row, int col)
    {
        Console.WriteLine("The max 3x3 submatrix is:");
        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                Console.Write(matrix[i, j] + "  ");
            }
            Console.WriteLine();
        }
    }

    private static int SumOfSquare(int[,] matrix, int row, int col)
    {
        int sum = 0;
        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                sum += matrix[i, j];
            }
        }
        return sum;
    }
}

