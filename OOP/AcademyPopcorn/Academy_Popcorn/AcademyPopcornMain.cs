using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            // Task 1
            for (int j = 1; j < WorldRows; j++)
            {
                IndestructibleBlock leftBlock = new IndestructibleBlock(new MatrixCoords(j, 0));
                IndestructibleBlock rightBlock = new IndestructibleBlock(new MatrixCoords(j, WorldCols - 1));
                engine.AddObject(leftBlock);
                engine.AddObject(rightBlock);
            }

            // Task 1
            for (int z = 0; z < WorldCols; z++)
            {
                IndestructibleBlock topBlock = new IndestructibleBlock(new MatrixCoords(1, z));
                engine.AddObject(topBlock);
            }

            UnstoppableBall theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            //TrailObject trail = new TrailObject(new MatrixCoords(10, 10), new char[,] { {'T'} }, 10);
            //engine.AddObject(trail);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
