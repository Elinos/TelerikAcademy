using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleSity
{
    public class Fire
    {
        public int StartRow { get; private set; }
        public int StartCol { get; private set; }
        public bool IsPlayerFire { get; private set; }
        public Directions Direction { get; private set; }
        public char Symbol { get; private set; }
        public ConsoleColor Color { get; private set; }
        public int CurrentRow { get; private set; }
        public int CurrentCol { get; private set; }
        public int OldRow { get; private set; }
        public int OldCol { get; private set; }

        public Fire(Tank tank)
        {
            this.IsPlayerFire = tank.IsPlayr;
            this.Direction = tank.Direction;
            this.Color = ConsoleColor.Black;
            if (Direction == Directions.Down)
            {
                this.StartRow = tank.CurrentRow + tank.Dimention;
                this.StartCol = tank.CurrentCol + (tank.Dimention / 2);
                this.Symbol = '|';
            }

            if (Direction == Directions.Right)
            {
                this.StartRow = tank.CurrentRow + (tank.Dimention / 2);
                this.StartCol = tank.CurrentCol + tank.Dimention;
                this.Symbol = '—';
            }

            if (Direction == Directions.Up)
            {
                this.StartRow = tank.CurrentRow - 1;
                this.StartCol = tank.CurrentCol + (tank.Dimention / 2);
                this.Symbol = '|';
            }

            if (Direction == Directions.Left)
            {
                this.StartRow = tank.CurrentRow + (tank.Dimention / 2);
                this.StartCol = tank.CurrentCol - 1;
                this.Symbol = '—';
            }

            OldRow = StartRow;
            OldCol = StartCol;
            CurrentRow = StartRow;
            CurrentCol = StartCol;
        }
        public void Move()
        {
            OldRow = CurrentRow;
            OldCol = CurrentCol;

            switch (Direction)
            {
                case Directions.Up: CurrentRow--;
                    break;
                case Directions.Down: CurrentRow++;
                    break;
                case Directions.Left: CurrentCol--;
                    break;
                case Directions.Right: CurrentCol++;
                    break;
                default:
                    break;
            }
        }
    }
}
