using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSity
{
    class NewPosition
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public NewPosition(Tank tank, Directions direction)
        {
            this.Row = tank.CurrentRow;
            this.Column = tank.CurrentCol;

            ChangeCordinate(direction);
        }

        public NewPosition(Fire misale)
        {
            this.Row = misale.CurrentRow;
            this.Column = misale.CurrentCol;

            ChangeCordinate(misale.Direction);
        }

        private void ChangeCordinate(Directions direction)
        {
            switch (direction)
            {
                case Directions.Up: this.Row--;
                    break;
                case Directions.Down: this.Row++;
                    break;
                case Directions.Left: this.Column--;
                    break;
                case Directions.Right: this.Column++;
                    break;
                case Directions.No:
                    break;
                default: throw new ArgumentException("Inavalide direction in collision class");
                //break;
            }
        }
    }

    public class Collision
    {
        private Element[,] mapElements;

        public ConsoleRender render;

        public Collision(Element[,] mapElements)
        {
            this.mapElements = mapElements;
            int width = Data.GetWindowWidth();
            int height = Data.GetWindowHeight();
            this.render = new ConsoleRender(width, height);
        }

        public bool CanTankMove(Tank tank, List<Tank> enemies, Directions direction)
        {
            NewPosition newTankPosition = new NewPosition(tank, direction);
            bool collides = false;


            if (newTankPosition.Row >= 2 && newTankPosition.Row < Data.GetWindowHeight() - 4 &&
                newTankPosition.Column >= 0 && newTankPosition.Column < Data.GetWindowWidth() - 3)
            {
                collides = true;
            }

            for (int elemRow = 0; elemRow < mapElements.GetLength(0); elemRow++)
            {
                for (int elemCol = 0; elemCol < mapElements.GetLength(1); elemCol++)
                {
                    if (mapElements[elemRow, elemCol] != null)
                    {
                        if (DoesItCollideTank(mapElements[elemRow, elemCol], tank, newTankPosition.Row, newTankPosition.Column))
                        {
                            collides = false;
                        }
                    }
                }
            }

            if (collides)
            {
                collides = TankIsOnAtherTank(tank, enemies, newTankPosition);
            }
            

            return collides;
        }

        private bool TankIsOnAtherTank(Tank tank, List<Tank> enemies, NewPosition newTankPosition)
        {
            bool collides = true;
            for (int i = 0; i < enemies.Count; i++)
            {
                if (tank.TankNumber != enemies[i].TankNumber)
                {
                    if (IsTankColaidsAtherTank(newTankPosition, enemies[i]))
                    {
                        collides = false;
                        break;
                    }
                }
            }
            return collides;
        }

        private bool IsTankColaidsAtherTank(NewPosition newTankPosition, Tank tank)
        {
            for (int row = newTankPosition.Row; row < newTankPosition.Row + Data.GetElementDimention(); row++)
            {
                for (int col = newTankPosition.Column; col < newTankPosition.Column + Data.GetElementDimention(); col++)
                {
                    if (row >= tank.CurrentRow && row < tank.CurrentRow + tank.Dimention &&
                        col >= tank.CurrentCol && col < tank.CurrentCol + tank.Dimention)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public bool DoesItCollideTank(Element elemPos, Tank tank, int tankRow, int tankCol)
        {
            bool collidesDoes = false;
            for (int t = -1; t < 2; t++)
            {
                for (int k = -1; k < 2; k++)
                {
                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            if ((elemPos.Row + i == tankRow + t) && (elemPos.Column + j == tankCol + k))
                            {
                                collidesDoes = true;
                            }
                        }
                    }
                }
            }
            return collidesDoes;
        }

        public bool CanFireMove(int fireRow, int fireCol)
        {
            bool collides = true;
            for (int elemRow = 0; elemRow < mapElements.GetLength(0); elemRow++)
            {
                for (int elemCol = 0; elemCol < mapElements.GetLength(1); elemCol++)
                {
                    if (mapElements[elemRow, elemCol] != null)
                    {
                        if (DoesItCollideFire(mapElements[elemRow, elemCol], fireRow, fireCol))
                        {
                            
                            if (mapElements[elemRow, elemCol].Type == ElementType.Braket ||
                                mapElements[elemRow, elemCol].Type == ElementType.Eagle)
                            {
                                collides = false;
                                render.DeleteElement(mapElements[elemRow, elemCol]);
                                mapElements[elemRow, elemCol] = null;
                            }
                            else
                            {
                                if (mapElements[elemRow, elemCol].Type == ElementType.Wother)
                                {
                                    render.DrawElement(mapElements[elemRow, elemCol]);
                                    collides = true;
                                }
                                else
                                {
                                    collides = false;
                                }
                                
                            }
                            
                        }
                    }
                }
            }
            return collides;
        }

        public bool DoesItCollideFire(Element elemPos, int fireRow, int fireCol)
        {
            bool collidesDoes = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((elemPos.Row + i == fireRow) && (elemPos.Column + j == fireCol))
                    {
                        collidesDoes = true;
                    }
                }
            }

            return collidesDoes;
        }

        public bool HaveShotCollision(Fire fire, Tank player, List<Tank> enemies)
        {
            // if have collision return true
            // else return false - misale continue move

            // Gencho make simple collision


            NewPosition newFirePosition = new NewPosition(fire);
            if (!CanFireMove(newFirePosition.Row, newFirePosition.Column))
            {
                return true; 
            }

            if (newFirePosition.Row >= 2 && newFirePosition.Row < Data.GetWindowHeight() - 2 &&
                newFirePosition.Column >= 0 && newFirePosition.Column < Data.GetWindowWidth() - 1)
            {
                // enemy fire
                if (!fire.IsPlayerFire)
                {
                    if (IsMisaleHitTank(player, newFirePosition))
                    {
                        player.IsHited = true;
                        return true;
                    }
                }
                else
                {
                    bool haveHit = false;
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        if (IsMisaleHitTank(enemies[i], newFirePosition))
                        {
                            enemies[i].IsHited = true;
                            haveHit = true;
                        }
                    }

                    if (haveHit)
                    {
                        return true;
                    }
                }

                return false;
            }


            return true;

            //if (IsFireAgainstEnemy(fire))
            //{
            //}
            //if (IsFireAgainstPlayer(fire))
            //{
            //}
            //if (IsFireAgainstTerain(fire))
            //{
            //}

        }

        private static bool IsMisaleHitTank(Tank player, NewPosition newFirePosition)
        {
            return newFirePosition.Row >= player.CurrentRow &&
                                    newFirePosition.Row <= (player.CurrentRow + Data.GetElementDimention() - 1) &&
                                    newFirePosition.Column >= player.CurrentCol &&
                                    newFirePosition.Column <= (player.CurrentCol + Data.GetElementDimention() - 1);
        }

    }
}
