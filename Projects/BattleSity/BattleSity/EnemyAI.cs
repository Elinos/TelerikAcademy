using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSity
{
    public static class EnemyAI
    {
        public static Fire Shoot(Tank player, Tank enemy, Random rand)
        {
            int shotChance = rand.Next(1, 101);
            Fire fire = null;

            if (shotChance < 13)
            {
                fire = new Fire(enemy);
            }

            return fire;
        }

        public static Directions Move(Tank player, Tank enemy, Random rand)
        {
            Directions direction = Directions.Up;

            int chance = rand.Next(1, 101);
            int numberDirection = rand.Next(0, 4);
            

            if (chance < 10)
            {
                direction = MoveToPlayer(player, enemy, rand);
            }
            else if (chance < 20)
            {
                direction += numberDirection;
            }
            else
            {
                direction = enemy.Direction;
            }

            return direction;
        }
  
        private static Directions MoveToPlayer(Tank player, Tank enemy, Random rand)
        {
            List<Directions> directionsToChooseFrom = new List<Directions>();

            if (player.CurrentCol < enemy.CurrentCol)
                directionsToChooseFrom.Add(Directions.Left);
            else if(player.CurrentCol > enemy.CurrentCol)
                directionsToChooseFrom.Add(Directions.Right);                

            if (player.CurrentRow < enemy.CurrentRow)
                directionsToChooseFrom.Add(Directions.Up);                  
            else if (player.CurrentRow > enemy.CurrentRow)
                directionsToChooseFrom.Add(Directions.Down);

            return directionsToChooseFrom[rand.Next(0, directionsToChooseFrom.Count)];
        }
  
        
    }
}
