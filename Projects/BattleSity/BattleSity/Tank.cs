using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSity
{
    public class Tank
    {
        private static Random random = new Random();
        public int Dimention { get; private set; }
        public Directions Direction { get; set; }
        public int Lives { get; set; }
        public int Score { get; private set; }
        public bool IsPlayr { get; private set; }

        public int TankNumber { get; private set; }

        public ConsoleColor Color { get; private set; }
        public char Sumbol { get; private set; }

        public int StartRow { get; private set; }
        public int StartCol { get; private set; }

        public int CurrentRow { get; private set; }
        public int CurrentCol { get; private set; }

        public int OldRow { get; private set; }
        public int OldCol { get; private set; }

        public bool IsHited { get; set; }

        public Tank(bool isPlayr, int startRow, int startCol, char sumbol = 'O', int tankNumber = -1)
        {
            Dimention = Data.GetElementDimention();
            this.Direction = Directions.Up;
            this.IsPlayr = isPlayr;
            this.Sumbol = sumbol;

            this.OldRow = startRow;
            this.OldCol = startCol;
            this.CurrentRow = startRow;
            this.CurrentCol = startCol;
            this.StartRow = startRow;
            this.StartCol = startCol;
            this.TankNumber = tankNumber;

            SetLivesAndColor(isPlayr);

            this.IsHited = false;
        }

        private void SetLivesAndColor(bool isPlayr)
        {
            this.Score = 0;

            if (isPlayr)
            {
                Color = ConsoleColor.Green;
                this.Lives = 3;
            }
            else
            {
                // max lives: 4
                int lives = GetEnemyLives();
                this.Score = lives * 100;

                ChoseColor(lives);
                
                this.Lives = lives;
            }
        }

        private int GetEnemyLives()
        {
            int lives = 0;

            int number = random.Next(0, 100);

            if (number < 50)
            {
                lives = 1;
            }
            else if (number < 70)
            {
                lives = 2;
            }
            else if (number < 90)
            {
                lives = 3;
            }
            else
            {
                lives = 4;
            }

            return lives;
        }

        private void ChoseColor(int lives)
        {
            switch (lives)
            {
                case 4: Color = ConsoleColor.DarkMagenta;
                    break;
                case 3: Color = ConsoleColor.Red;
                    break;
                case 2: Color = ConsoleColor.Blue;
                    break;
                case 1: Color = ConsoleColor.Gray;
                    break;
                default:
                    break;
            }
        }

        public void DecreaseLives()
        {
            if (Lives > 0)
            {
                Lives--;
            }

            if (!IsPlayr)
            {
                ChoseColor(Lives);
            }
        }

        public void Move(Directions direction)
        {
            this.Direction = direction;
            OldRow = CurrentRow;
            OldCol = CurrentCol;

            switch (direction)
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

        public void SetDefitedCordinates()
        {
            this.OldRow = this.CurrentRow;
            this.OldCol = this.CurrentCol;
        }

        public void MakeStartPosition()
        {
            this.CurrentRow = this.StartRow;
            this.CurrentCol = this.StartCol;
        }
    }
}
