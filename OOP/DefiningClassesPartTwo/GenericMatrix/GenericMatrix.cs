using System;
using System.Text;

namespace GenericMatrix
{
    // Task 8
    class GenericMatrix<T>
    where T : struct, IComparable, IFormattable
    {
        T[,] matrix;
        private readonly int rows;
        private readonly int cols;

        public GenericMatrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            matrix = new T[rows, cols];
        }

        public T this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }

        public static GenericMatrix<T> operator +(GenericMatrix<T> m1, GenericMatrix<T> m2)
        {
            if (m1.rows != m2.rows || m1.cols != m2.cols)
            {
                throw new ArgumentException("Matrices must be the same size.");
            }

            GenericMatrix<T> newMatrix = new GenericMatrix<T>(m1.rows, m1.cols);
            for (int row = 0; row < m1.rows; row++)
            {
                for (int col = 0; col < m1.cols; col++)
                {
                    newMatrix[row, col] = (dynamic)m1[row, col] + (dynamic)m2[row, col];
                }
            }
            return newMatrix;
        }

        public static GenericMatrix<T> operator -(GenericMatrix<T> m1, GenericMatrix<T> m2)
        {
            if (m1.rows != m2.rows || m1.cols != m2.cols)
            {
                throw new ArgumentException("Matrices must be the same size.");
            }

            GenericMatrix<T> newMatrix = new GenericMatrix<T>(m1.rows, m1.cols);
            for (int row = 0; row < m1.rows; row++)
            {
                for (int col = 0; col < m1.cols; col++)
                {
                    newMatrix[row, col] = (dynamic)m1[row, col] - (dynamic)m2[row, col];
                }
            }
            return newMatrix;
        }

        // 1 2 3
        // 4 5 6

        // 1 2 3 4
        // 3 4 3 4
        // 5 6 3 4

        public static GenericMatrix<T> operator *(GenericMatrix<T> firstMatrix, GenericMatrix<T> secondMatrix)
        {
            int n = firstMatrix.rows;
            int m = secondMatrix.cols;
            int l = firstMatrix.cols;
            if (l != secondMatrix.rows)
                throw new ArgumentException("Illegal matrix dimensions for multiplication. Cols of firstMatrix must be equal to Rows of secondMatrix");
            GenericMatrix<T> result = new GenericMatrix<T>(firstMatrix.rows, secondMatrix.cols);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    dynamic sum = default(T);
                    for (int k = 0; k < l; k++)
                        sum += (dynamic)firstMatrix.matrix[i, k] * secondMatrix.matrix[k, j];
                    result.matrix[i, j] = sum;
                }
            return result;
        }

        //public static GenericMatrix<T> operator *(GenericMatrix<T> m1, GenericMatrix<T> m2)
        //{
        //    if (m1.rows != m2.rows || m1.cols != m2.cols)
        //    {
        //        throw new ArgumentException("Matrices must be the same size.");
        //    }

        //    GenericMatrix<T> newMatrix = new GenericMatrix<T>(m1.rows, m1.cols);
        //    for (int row = 0; row < m1.rows; row++)
        //    {
        //        for (int col = 0; col < m1.cols; col++)
        //        {
        //            newMatrix[row, col] = (dynamic)m1[row, col] - (dynamic)m2[row, col];
        //        }
        //    }
        //    return newMatrix;
        //}

        public static bool operator true(GenericMatrix<T> m)
        {
            bool nonZero = false;
            for (int row = 0; row < m.rows; row++)
            {
                for (int col = 0; col < m.cols; col++)
                {
                    nonZero = m.matrix[row, col].Equals(default(T)) ? false : true;
                    if (nonZero) return true;
                }
            }

            return nonZero;
        }

        public static bool operator false(GenericMatrix<T> m)
        {
            bool zero = true;
            for (int row = 0; row < m.rows; row++)
            {
                for (int col = 0; col < m.cols; col++)
                {
                    zero = m.matrix[row, col].Equals(default(T)) ? true : false;
                    if (!zero) return false;
                }
            }

            return zero;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.cols; col++)
                {
                    sb.Append(this.matrix[row, col]);
                    sb.Append("\t");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
