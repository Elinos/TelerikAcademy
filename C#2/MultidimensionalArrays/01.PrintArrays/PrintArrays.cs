//1. Write a program that fills and prints a matrix of size (n, n)
using System;

class PrintArrays
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        SolutionA(n);
        SolutionB(n);
        SolutionC(n);
        SolutionD(n);
    }

    private static void SolutionA(int n)
    {
        int[,] matixA = new int[n, n];
        int number = 0;
        for (int col = 0; col < matixA.GetLength(1); col++)
        {
            for (int row = 0; row < matixA.GetLength(0); row++)
            {
                number++;
                matixA[row, col] = number;
            }
        }
        Console.WriteLine("Matrix A:");
        PrintMatrix(matixA);
        Console.WriteLine();
    }

    private static void SolutionB(int n)
    {
        int[,] matrixB = new int[n, n];
        int col = 0;
        int row = 0;
        int direction = 1;
        matrixB[row, col] = 1;
        for (int number = 2; number <= n * n; number++)
        {
            row = row + (1 * direction);
            if (row % (n - 1) == 0)
            {
                matrixB[row, col] = number;
                direction *= -1;
                if (col != n - 1)
                    col++;
                else
                    break;
                matrixB[row, col] = ++number;
            }
            else
                matrixB[row, col] = number;
        }
        Console.WriteLine("Matrix B:");
        PrintMatrix(matrixB);
        Console.WriteLine();
    }

    private static void SolutionC(int n)
    {
        int[,] matrixC = new int[n, n];
        int number = 1;

        for (int i = 0; i <= n - 1; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                matrixC[n - i + j - 1, j] = number++;
            }
        }
        for (int i = n - 2; i >= 0; i--)
        {
            for (int j = i; j >= 0; j--)
            {
                matrixC[i - j, n - j - 1] = number++;
            }
        }
        Console.WriteLine("Matrix C:");
        PrintMatrix(matrixC);
        Console.WriteLine();
    }

    private static void SolutionD(int n)
    {
        int[,] matrixD = new int[n, n];
        string direction = "down";

        int row = 0;
        int col = 0;

        for (int i = 1; i <= n * n; i++)
        {
            matrixD[row, col] = i;

            if (direction == "right")
            {
                if ((col + 1 != n) && (matrixD[row, col + 1] == 0))
                    col++;
                else
                {
                    direction = "up";
                    row--;
                }
            }
            else if (direction == "down")
            {
                if ((row + 1 != n) && (matrixD[row + 1, col] == 0))
                    row++;
                else
                {
                    direction = "right";
                    col++;
                }
            }
            else if (direction == "left")
            {
                if ((col > 0) && (matrixD[row, col - 1] == 0))
                    col--;
                else
                {
                    direction = "down";
                    row++;
                }
            }
            else if (direction == "up")
            {
                if ((row > 0) && (matrixD[row - 1, col] == 0))
                    row--;
                else
                {
                    direction = "left";
                    col--;
                }
            }
        }
        Console.WriteLine("Matrix D:");
        PrintMatrix(matrixD);
    }

    public static void PrintMatrix(int[,] matrix)
    {
        Console.WriteLine(new string('-', 4 * matrix.GetLength(0) - 1));
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,-2}| ", matrix[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine(new string('-', 4 * matrix.GetLength(0) - 1));
    }
}

