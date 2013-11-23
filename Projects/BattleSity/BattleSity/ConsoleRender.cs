using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSity
{
    public class ConsoleRender
    {
        private int width;
        private int height;

        public ConsoleRender(int width, int height)
        {
            this.width = width;
            this.height = height;

            SetConsoleSetings();
        }

        private void SetConsoleSetings()
        {
            Console.WindowWidth = this.width;
            Console.BufferWidth = this.width;
            Console.WindowHeight = this.height;
            Console.BufferHeight = this.height;
            Console.CursorVisible = false;
        }

        public void Misale(Fire misale)
        {
            DeleteMisale(misale);

            Console.ForegroundColor = misale.Color;
            Console.BackgroundColor = ConsoleColor.White;

            char symbol = misale.Symbol;

            Console.SetCursorPosition(misale.CurrentCol, misale.CurrentRow);
            Console.Write(symbol);
                
            Console.ResetColor();
        }

        public void DeleteMisale(Fire misale)
        {
            Console.ForegroundColor = misale.Color;
            Console.BackgroundColor = ConsoleColor.White;

            char symbol = ' ';

            Console.SetCursorPosition(misale.OldCol, misale.OldRow);
            Console.Write(symbol);

            Console.ResetColor();
        }

        public void Tank(Tank tank)
        {
            DeleteTank(tank);

            switch (tank.Direction)
            {
                case Directions.Up:  DrowTankUp(tank);
                    break;
                case Directions.Down:  DrowTankDown(tank);
                    break;
                case Directions.Left:  DrowTankLeft(tank);
                    break;
                case Directions.Right:  DrowTankRight(tank);
                    break;
                default:
                    break;
            }
        }

        private void DrowTankUp(Tank tank)
        {
            Console.ForegroundColor = tank.Color;
            Console.BackgroundColor = ConsoleColor.White;

            string str = new string(tank.Sumbol, tank.Dimention);

            for (int row = 0; row < tank.Dimention; row++)
            {
                for (int col = 0; col < tank.Dimention; col++)
                {
                    if (row == 0 && col == (tank.Dimention) / 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(tank.CurrentCol + col, tank.CurrentRow + row);
                        Console.Write(str[col]);
                        Console.ForegroundColor = tank.Color;
                    }
                    else
                    {
                        Console.SetCursorPosition(tank.CurrentCol + col, tank.CurrentRow + row);
                        Console.Write(str[col]);
                    }
                    
                }
                
            }

            Console.ResetColor();
        }

        private void DrowTankDown(Tank tank)
        {
            Console.ForegroundColor = tank.Color;
            Console.BackgroundColor = ConsoleColor.White;

            string str = new string(tank.Sumbol, tank.Dimention);

            for (int row = 0; row < tank.Dimention; row++)
            {
                for (int col = 0; col < tank.Dimention; col++)
                {
                    if (row == tank.Dimention - 1 && col == (tank.Dimention) / 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(tank.CurrentCol + col, tank.CurrentRow + row);
                        Console.Write(str[col]);
                        Console.ForegroundColor = tank.Color;
                    }
                    else
                    {
                        Console.SetCursorPosition(tank.CurrentCol + col, tank.CurrentRow + row);
                        Console.Write(str[col]);
                    }
                }

            }

            Console.ResetColor();
        }

        private void DrowTankLeft(Tank tank)
        {
            Console.ForegroundColor = tank.Color;
            Console.BackgroundColor = ConsoleColor.White;

            string str = new string(tank.Sumbol, tank.Dimention);

            for (int row = 0; row < tank.Dimention; row++)
            {
                for (int col = 0; col < tank.Dimention; col++)
                {
                    if (row == (tank.Dimention) / 2 && col == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(tank.CurrentCol + col, tank.CurrentRow + row);
                        Console.Write(str[col]);
                        Console.ForegroundColor = tank.Color;
                    }
                    else
                    {
                        Console.SetCursorPosition(tank.CurrentCol + col, tank.CurrentRow + row);
                        Console.Write(str[col]);
                    }
                }

            }

            Console.ResetColor();
        }

        private void DrowTankRight(Tank tank)
        {
            Console.ForegroundColor = tank.Color;
            Console.BackgroundColor = ConsoleColor.White;

            string str = new string(tank.Sumbol, tank.Dimention);

            for (int row = 0; row < tank.Dimention; row++)
            {
                for (int col = 0; col < tank.Dimention; col++)
                {
                    if (row == (tank.Dimention) / 2 && col == tank.Dimention - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(tank.CurrentCol + col, tank.CurrentRow + row);
                        Console.Write(str[col]);
                        Console.ForegroundColor = tank.Color;
                    }
                    else
                    {
                        Console.SetCursorPosition(tank.CurrentCol + col, tank.CurrentRow + row);
                        Console.Write(str[col]);
                    }
                }

            }

            Console.ResetColor();
        }

        public void DeleteTank(Tank tank)
        {
            Console.BackgroundColor = ConsoleColor.White;
            string str = new string(' ', tank.Dimention);
            Console.CursorVisible = false;

            for (int row = 0; row < tank.Dimention; row++)
            {
                for (int col = 0; col < tank.Dimention; col++)
                {
                    Console.SetCursorPosition(tank.OldCol + col, tank.OldRow + row);
                    Console.Write(str[col]);
                }
            }

        }

        public void Level(char[,] level)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;

            for (int row = 0; row < level.GetLength(0); row++)
            {
                for (int col = 0; col < level.GetLength(1); col++)
                {
                    Console.SetCursorPosition(col, row);
                    Console.Write(level[row, col]);
                }
            }

            Console.ResetColor();
        }

        public void Level(Element[,] elements)
        {
            WhiteGameFild();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;

            for (int row = 0; row < elements.GetLength(0); row++)
            {
                for (int col = 0; col < elements.GetLength(1); col++)
                {
                    if (elements[row, col] != null)
                    {
                        DrawElement(elements[row, col]);
                    }
                }
            }

            Console.ResetColor();
        }

        public void DrawElement(Element element)
        {
            switch (element.Type)
            {
                case ElementType.Wother: DrowWater(element);
                    break;
                case ElementType.Braket: DrowBraket(element);
                    break;
                case ElementType.Steel: DrowSteel(element);
                    break;
                case ElementType.Eagle: DrowEagle(element);
                    break;
                case ElementType.Empty: DeleteElement(element);
                    break;
                default:
                    break;
            }
        }

        private void DrowEagle(Element eagle)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.SetCursorPosition(eagle.Column, eagle.Row);
            Console.Write(" @ ");
            Console.SetCursorPosition(eagle.Column, eagle.Row + 1);
            Console.Write("<O>");
            Console.SetCursorPosition(eagle.Column, eagle.Row + 2);
            Console.Write("/ \\");
                

            Console.ResetColor();
        }

        private void DrowSteel(Element steel)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.White;

            string str = new string('#', steel.Dimention);

            for (int row = 0; row < steel.Dimention; row++)
            {
                for (int col = 0; col < steel.Dimention; col++)
                {
                    Console.SetCursorPosition(steel.Column + col, steel.Row + row);
                    Console.Write(str[col]);
                }

            }

            Console.ResetColor();
        }

        private void DrowWater(Element water)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;

            string str = new string('~', water.Dimention);

            for (int row = 0; row < water.Dimention; row++)
            {
                for (int col = 0; col < water.Dimention; col++)
                {
                    Console.SetCursorPosition(water.Column + col, water.Row + row);
                    Console.Write(str[col]);
                }

            }

            Console.ResetColor();
        }

        private void DrowBraket(Element braket)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.White;

            string str = new string('W' , braket.Dimention);

            for (int row = 0; row < braket.Dimention; row++)
            {
                for (int col = 0; col < braket.Dimention; col++)
                {
                    Console.SetCursorPosition(braket.Column + col, braket.Row + row);
                    Console.Write(str[col]);
                }

            }

            Console.ResetColor();
        }

        public void DeleteElement(Element element)
        {
            Console.BackgroundColor = ConsoleColor.White;
            string str = new string(' ', element.Dimention);
            Console.CursorVisible = false;

            for (int row = 0; row < element.Dimention; row++)
            {
                for (int col = 0; col < element.Dimention; col++)
                {
                    Console.SetCursorPosition(element.Column + col, element.Row + row);
                    Console.Write(str[col]);
                }
            }
        }

        public void MenuItem(int row, int col, string text, ConsoleColor color, 
                                ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = color;
            Console.CursorVisible = false;

            Console.SetCursorPosition(col, row);

            Console.Write(text);

            Console.ResetColor();
        }

        public void FillConsoleBackgroundColor(ConsoleColor color = ConsoleColor.Black)
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = color;

            string str = new string(' ', width);

            for (int row = 0; row < height; row++)
            {
                Console.SetCursorPosition(0, row);

                Console.Write(str);
            }
        }

        public void WhiteGameFild()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;

            string str = new string(' ', width);

            for (int row = 2; row < height; row++)
            {
                Console.SetCursorPosition(0, row);

                Console.Write(str);
            }
        }
    }
}
