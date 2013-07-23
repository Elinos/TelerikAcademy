using System;

class ClassMatrix
{
    static void Main()
    {
        Matrix matrix1 = new Matrix(2, 2);
        matrix1[0, 0] = 3;
        matrix1[0, 1] = 4;
        matrix1[1, 0] = -7;
        matrix1[1, 1] = 2;
        Console.WriteLine("The first matrix:\n{0}", matrix1);

        Matrix matrix2 = new Matrix(2, 2);
        matrix2[0, 0] = 12;
        matrix2[0, 1] = -6;
        matrix2[1, 0] = 43;
        matrix2[1, 1] = 0;
        Console.WriteLine("The second matrix:\n{0}", matrix2);

        Matrix sum = matrix1 + matrix2;
        Console.WriteLine("The sum of both matrixes:\n{0}",sum.ToString());
    }
}
class Matrix
{
    private int[,] matrix;

    public Matrix(int rows, int cols)
    {
        this.matrix = new int[rows, cols];
    }

    public int Rows
    {
        get
        {
            return this.matrix.GetLength(0);
        }
    }

    public int Columns
    {
        get
        {
            return this.matrix.GetLength(1);
        }
    }

    public static Matrix operator +
        (Matrix first, Matrix second)
    {
        Matrix result = new Matrix(first.Rows, first.Columns);
        for (int row = 0; row < first.Rows; row++)
        {
            for (int col = 0; col < first.Columns; col++)
            {
                result[row, col] = first[row, col] + second[row, col];
            }
        }
        return result;
    }

    public int this[int row, int col]
    {
        get
        {
            return this.matrix[row, col];
        }

        set
        {
            this.matrix[row, col] = value;
        }
    }

    public override string ToString()
    {
        string result = String.Empty;
        for (int row = 0; row < this.Rows; row++)
        {
            for (int col = 0; col < this.Columns; col++)
            {
                result += matrix[row, col] + "  ";
            }
            result += Environment.NewLine;
        }
        return result;
    }
}
