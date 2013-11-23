using System;

namespace BattleSity
{
    [Serializable]
    public class Element
    {
        public ElementType Type { get; private set; }
        public  readonly static char DefaultSumbol = 'W';
        public  readonly static char EmptySymbol = ' ';

        public int Row { get; private set; }
        public int Column { get; private set; }

        public int Dimention { get; private set; }

        public char[,] Matrix { get; private set; }

        public Element(ElementType @type, int row, int column)
        {
            this.Type = @type;
            this.Row = row;
            this.Column = column;
            this.Dimention = Data.GetElementDimention();

            FillMatrix();
        }

        private void FillMatrix()
        {
            char[,] matrix = new char[this.Dimention, this.Dimention];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = DefaultSumbol;
                }
            }

            this.Matrix = matrix;
        }

        public void RemoveColumn(int column)
        {
            if (column < Dimention && column >= 0)
            {
                for (int row = 0; row < this.Matrix.GetLength(0); row++)
                {
                    this.Matrix[row, column] = EmptySymbol;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid COLUMN for remove!");
            }

        }

        public void RemoveRow(int row)
        {
            if (row < Dimention && row >= 0)
            {
                for (int col = 0; col < this.Matrix.GetLength(0); col++)
                {
                    this.Matrix[row, col] = EmptySymbol;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid ROW for remove!");
            }

        }
    }
}
