using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.ExistingPathInLabyrinth
{
    class Position
    {
        private int row;
        private int col;

        public Position(int row, int col)
        {
            // TODO: Complete member initialization
            this.row = row;
            this.col = col;
        }

        public int Row
        {
            get
            {
                return this.row;
            }
            set
            {
                this.row = value;
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }
            set
            {
                this.col = value;
            }
        }
    }
}
