using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleSity
{
    class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }
    }

    public class GameEngine
    {
        private int score;
        private bool isEscapePressed;
        private bool havePlayerFire;
        private ConsoleRender render;
        private Element[,] level;
        private bool isExit;
        private List<Tank> enemys;
        private Position[] startEnemyPositions;
        private int createEnemyCallCount;
        private Random rand;
        private List<Fire> playerMisals;
        private List<Fire> enemyMisals;
        private Collision collision;
        private int enemyOnLevel;
        private int enemyPlayCount;
        private int enemyNumber;

        private int oldPlayerLives;
        private int oldScore;
        private int oldenemyOnLevel;

        public GameEngine(uint levelNumber)
        {
            int width = Data.GetWindowWidth();
            int height = Data.GetWindowHeight();
            this.render = new ConsoleRender(width, height);

            this.level = Data.GetLevel(levelNumber);
            havePlayerFire = false;
            isExit = false;
            this.enemys = new List<Tank>();
            FillStartEnemyPositions();
            createEnemyCallCount = 0;
            rand = new Random();
            this.playerMisals = new List<Fire>();
            this.enemyMisals = new List<Fire>();
            this.collision = new Collision(level);
            this.enemyOnLevel = 20;
            this.isEscapePressed = false;
            this.enemyPlayCount = 0;
            this.enemyNumber = 0;
        }

        private void FillStartEnemyPositions()
        {
            int enemyStartRow = 2;
            int enemyPositions = 3;
            startEnemyPositions = new Position[enemyPositions];
            Position first = new Position();
            first.Row = enemyStartRow;
            first.Column = 0;
            startEnemyPositions[0] = first;

            Position second = new Position();
            second.Row = enemyStartRow;
            second.Column = (Data.GetWindowWidth() / 2) - Data.GetElementDimention();
            startEnemyPositions[1] = second;

            Position third = new Position();
            third.Row = enemyStartRow;
            third.Column = Data.GetWindowWidth() - Data.GetElementDimention() -
                                            (Data.GetWindowWidth() % Data.GetElementDimention());
            startEnemyPositions[2] = third;
        }

        public FinishGameMessage Start()
        {
            FinishGameMessage finishMessage = new FinishGameMessage();
            render.Level(this.level);
            int playerStartRow = Data.GetWindowHeight() - 2 * Data.GetElementDimention();
            int playerStartCol = (Data.GetWindowWidth() / 2) - 3 * Data.GetElementDimention();

            Tank player = new Tank(true, playerStartRow, playerStartCol);
            render.Tank(player);
            int moveEnemyMisalesCount = 0;
            int playrMoveCount = 0;
            long playrFireCount = 0;

            this.oldPlayerLives = player.Lives;
            this.oldScore = 0;
            this.oldenemyOnLevel = this.enemyOnLevel;

            while (!isExit)
            {
                ShowInformation(player);

                moveEnemyMisalesCount++;
                if (moveEnemyMisalesCount > 1)
                {
                    moveEnemyMisalesCount = 0;
                    MoveEnemyMisales(player);
                }

                MovePlayesMisales(player);

                if (CheckPlayerWin())
                {
                    isExit = true;
                    finishMessage.Score = this.score;
                    finishMessage.IsGameOver = false;
                    finishMessage.Message = "Player WIN no enemy left";
                }
                else
                {
                    playrMoveCount++;
                    if (playrMoveCount > 1)
                    {
                        playrMoveCount = 0;
                        PlayerMove(player);
                    }

                    // player fire
                    playrFireCount++;
                    if (havePlayerFire && playrFireCount > 10)
                    {
                        playrFireCount = 0;
                        havePlayerFire = false;
                        this.playerMisals.Add(new Fire(player)); // when shot move it draw.
                    }

                    CreateEnemy();
                    EnemyPlay(player);

                    if (player.Lives <= 0)
                    {
                        isExit = true;
                        finishMessage.Score = this.score;
                        finishMessage.IsGameOver = true;
                        finishMessage.Message = "lives player = 0";
                    }

                    Thread.Sleep(10);
                }
            }

            if (this.isEscapePressed)
            {
                finishMessage.Score = -1;
                finishMessage.IsGameOver = true;
                finishMessage.Message = "Escape pressed";
            }

            return finishMessage;
        }

        private void ShowInformation(Tank player)
        {
            if (this.oldenemyOnLevel != this.enemyOnLevel ||
                this.oldScore != this.score ||
                this.oldPlayerLives != player.Lives)
            {
                string info = String.Format("LIVES: {0}           SCORE: {1,7}           ENEMY to create: {2,2}",
                                player.Lives, this.score, this.enemyOnLevel);

                this.render.MenuItem(0, 1, info, ConsoleColor.Yellow);

                this.oldenemyOnLevel = this.enemyOnLevel;
                this.oldScore = this.score;
                this.oldPlayerLives = player.Lives;
            }

        }

        private bool CheckPlayerWin()
        {
            if (this.enemys.Count == 0 && this.enemyOnLevel <= 0)
            {
                return true;
            }

            return false;
        }

        private void MovePlayesMisales(Tank player)
        {
            // enemy fires move
            List<Fire> misalesFire = new List<Fire>();
            foreach (Fire misale in this.playerMisals)
            {
                if (!collision.HaveShotCollision(misale, player, this.enemys))
                {
                    misale.Move();
                    this.render.Misale(misale);   //draw missile
                    misalesFire.Add(misale);
                }
                else
                {
                    misale.Move();
                    // if have collision delete missile from Console
                    try
                    {
                        this.render.DeleteMisale(misale);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        // missile i out of map don't delete it
                    }

                    for (int i = 0; i < this.enemys.Count; i++)
                    {
                        if (this.enemys[i].IsHited)
                        {
                            this.enemys[i].DecreaseLives();
                            this.enemys[i].IsHited = false;
                            this.render.Tank(this.enemys[i]);

                            if (this.enemys[i].Lives <= 0)
                            {
                                Console.Beep(5500, 40);
                                this.score += this.enemys[i].Score;
                                this.enemys[i].SetDefitedCordinates();
                                render.DeleteTank(this.enemys[i]);
                                this.enemys.Remove(this.enemys[i]);
                            }
                        }
                    }



                    int eagleRow = this.level.GetLength(0) - 1;
                    int eagleCol = (this.level.GetLength(1) - 1) / 2;

                    // if there is no eagle set player live = 0 and this will make game over
                    if (this.level[eagleRow, eagleCol] == null)
                    {
                        while (player.Lives > 0)
                        {
                            player.DecreaseLives();
                        }

                        return;
                    }
                }
            }

            this.playerMisals = misalesFire;
        }

        private void EnemyPlay(Tank player)
        {
            this.enemyPlayCount++;

            if (enemyPlayCount > 4)
            {
                this.enemyPlayCount = 0;

                Directions directin = Directions.No;
                bool isValidDirection = false;

                // enemy Move and create missile
                foreach (Tank enemy in this.enemys)
                {
                    // create misale
                    Fire fire = EnemyAI.Shoot(player, enemy, this.rand);
                    if (fire != null && !enemy.IsPlayr)
                    {
                        if (this.collision.CanFireMove(fire.CurrentRow, fire.CurrentCol))
                        {
                            this.enemyMisals.Add(fire);
                        }
                        
                    }

                    // move
                    directin = EnemyAI.Move(player, enemy, this.rand);
                    
                    isValidDirection = this.collision.CanTankMove(enemy, this.enemys, directin);

                    if (isValidDirection)
                    {
                        List<Tank> playerList = new List<Tank>();
                        playerList.Add(player);
                        isValidDirection = this.collision.CanTankMove(enemy, playerList, directin);
                    }

                    if (isValidDirection && !enemy.IsPlayr)
                    {
                        enemy.Move(directin);
                        this.render.Tank(enemy);
                    }
                }

            }

        }

        private void MoveEnemyMisales(Tank player)
        {
            // enemy fires move
            List<Fire> misales = new List<Fire>();
            foreach (Fire misale in this.enemyMisals)
            {
                if (!collision.HaveShotCollision(misale, player, this.enemys))
                {
                    misale.Move();
                    this.render.Misale(misale);
                    misales.Add(misale);

                    for (int i = 0; i < this.enemys.Count; i++)
                    {
                        if (this.collision.DoesItCollideFire(new Element(ElementType.Braket, enemys[i].CurrentRow, enemys[i].CurrentCol),
                                                                            misale.CurrentRow, misale.CurrentCol))
                        {
                            this.render.Tank(enemys[i]);
                        }
                    }
                }
                else if (player.IsHited)
                {
                    // if have collision delete missile from Console
                    misale.Move();
                    try
                    {
                        this.render.DeleteMisale(misale);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        // missile is out of map don't delete it
                    }

                    Console.Beep(280, 200);
                    Console.Beep(480, 200);
                    Console.Beep(680, 100);
                    player.DecreaseLives();
                    player.IsHited = false;

                    player.SetDefitedCordinates();
                    this.render.DeleteTank(player);

                    if (player.Lives > 0)
                    {
                        player.MakeStartPosition();
                        render.Tank(player);
                    }
                }
                else
                {
                    misale.Move();
                    // if have collision delete misale from Console
                    try
                    {
                        this.render.DeleteMisale(misale);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        // missale i out of map donot delete it
                    }

                    int eagleRow = this.level.GetLength(0) - 1;
                    int eagleCol = (this.level.GetLength(1) - 1) / 2;

                    // if there is no eagle set player live = 0 and this will make game over
                    if (this.level[eagleRow, eagleCol] == null)
                    {
                        while (player.Lives > 0)
                        {
                            player.DecreaseLives();
                        }

                        return;
                    }
                }
            }

            this.enemyMisals = misales;
        }

        private void CreateEnemy()
        {
            if (createEnemyCallCount < 15)
            {
                createEnemyCallCount++;
            }

            int maxEnemyOnMap = 6;

            if (createEnemyCallCount > 10 &&
                    this.enemys.Count <= maxEnemyOnMap &&
                    this.enemyOnLevel > 0)
            {
                createEnemyCallCount = 0;
                int createdChance = rand.Next(1, 101);

                if (createdChance < 30)
                {
                    int positionNumber = rand.Next(0, 3);
                    this.enemyNumber++;

                    Tank enemy = new Tank(false, startEnemyPositions[positionNumber].Row,
                                                startEnemyPositions[positionNumber].Column, 'E', this.enemyNumber);
                    if (this.collision.CanTankMove(enemy, this.enemys, Directions.No))
                    {
                        this.enemyOnLevel--;
                        enemys.Add(enemy);
                        render.Tank(enemy);
                    }
                    else
                    {
                         ///
                    }
                    
                }
            }
        }

        private void PlayerMove(Tank player)
        {
            Directions newDirection = Directions.Up;

            newDirection = ReadDirectionAndFire();

            if (newDirection != Directions.No)
            {
                if (this.collision.CanTankMove(player, this.enemys, newDirection))
                {
                    Console.Beep(100, 30);
                    player.Move(newDirection);

                    render.Tank(player);
                }
                else
                {
                    player.Direction = newDirection;
                    this.render.Tank(player);
                }
            }
        }

        private Directions ReadDirectionAndFire()
        {
            Directions direction = Directions.No;
            ConsoleKeyInfo presedKey = new ConsoleKeyInfo();

            if (Console.KeyAvailable)
            {
                presedKey = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (presedKey.Key == ConsoleKey.Spacebar)
                {
                    havePlayerFire = true;
                }
                else if (presedKey.Key == ConsoleKey.UpArrow)
                {
                    direction = Directions.Up;
                }
                else if (presedKey.Key == ConsoleKey.DownArrow)
                {
                    direction = Directions.Down;
                }
                else if (presedKey.Key == ConsoleKey.LeftArrow)
                {
                    direction = Directions.Left;
                }
                else if (presedKey.Key == ConsoleKey.RightArrow)
                {
                    direction = Directions.Right;
                }
                else if (presedKey.Key == ConsoleKey.Escape)
                {
                    this.isEscapePressed = true;
                    this.isExit = true;
                }
            }

            return direction;
        }

    }
}
