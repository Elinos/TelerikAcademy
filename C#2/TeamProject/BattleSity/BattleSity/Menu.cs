using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace BattleSity
{
    public class Menu
    {
        private ConsoleRender render;
        private int rowText;
        private int colText;
        private int choiseRow;
        private int rowDistance;
        private bool isExit;
        private uint levelNumber;

        public Menu()
        {
            int width = Data.GetWindowWidth();
            int height = Data.GetWindowHeight();
            this.render = new ConsoleRender(width, height);

            // set text menu position
            this.rowText = height / 2;
            this.colText = width / 2;
            this.choiseRow = this.rowText; // set default choice position
            this.rowDistance = 2; // distance between printed rows

            isExit = false;
            this.levelNumber = 0;
        }

        public void Load()
        {
            //LevelEditorEngine.CreateLevel();

            //GameEngine game = new GameEngine();

            //game.Start();

            try
            {
                ShowStartMenu();
                ShowChoise();

                while (!isExit)
                {
                    ChangeChoise();

                    Thread.Sleep(30);
                }
            }
            catch (Exception e)
            {
                //ShowErrorMessage(e.Message);
                ShowErrorMessage(ConsoleColor.White, ConsoleColor.DarkBlue, "Un expected ERROR!", "", "TO EXIT -> ");
                StringBuilder error = new StringBuilder();
                error.AppendLine(DateTime.Now.ToString());
                error.AppendLine(e.ToString()); 
                File.AppendAllText("error.log", error.ToString());
            }
        }

        private void ChangeChoise()
        {
            int maxLevel = Data.GetNumberOfLevels();
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo();

            if (Console.KeyAvailable)
            {
                pressedKey = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (pressedKey.Key == ConsoleKey.LeftArrow &&
                                (rowText - rowDistance) == choiseRow && this.levelNumber > 1)
                {
                    this.levelNumber--;
                    ShowStartMenu();
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow &&
                                (rowText - rowDistance) == choiseRow && this.levelNumber < maxLevel)
                {
                    this.levelNumber++;
                    ShowStartMenu();
                }
                else if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    if (choiseRow > rowText - rowDistance)
                    {
                        HideChoise();
                        choiseRow -= rowDistance;
                        ShowChoise();
                    }
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    if (choiseRow < rowText + rowDistance * 2)
                    {
                        HideChoise();
                        choiseRow += rowDistance;
                        ShowChoise();
                    }
                }
                else if (pressedKey.Key == ConsoleKey.Enter)
                {
                    EnterPressed();
                }
            }
        }

        private void EnterPressed()
        {
            // START  GAME
            if (rowText == choiseRow)
            {
                StartGame();
            }
            else if ((rowText + rowDistance) == choiseRow)
            {
                //Create Level
                render.FillConsoleBackgroundColor();
                // Save created level
                Element[,] elements = LevelEditorEngine.CreateLevel();

                if (IsSaveLevel())
                {
                    Data.SaveLevel(elements);
                }

                ShowStartMenu();
                ShowChoise();
            }
            else if ((rowText + rowDistance * 2) == choiseRow)
            {
                isExit = true;
                render.MenuItem(choiseRow + rowDistance,
                            colText - rowDistance, " ", ConsoleColor.Gray);
            }
        }

        private void StartGame()
        {
            if (Data.GetNumberOfLevels() > 0 && levelNumber > 0)
            {
                try
                {
                    bool haveNextLeve = true;
                    //isStartGame = true;
                    while (haveNextLeve)
                    {
                        GameEngine game = new GameEngine(levelNumber);

                        FinishGameMessage message = game.Start();

                        ShowPlayrResults(message);



                        if ((Data.GetNumberOfLevels() < this.levelNumber + 1) || message.IsGameOver)
                        {
                            haveNextLeve = false;
                        }
                        else if (Data.GetNumberOfLevels() <= this.levelNumber + 1)
                        {
                            this.levelNumber++;
                        }
                    }

                }
                catch (System.IO.FileNotFoundException)
                {
                    string[] messages = new string[]{
                        String.Format("!!! Level: {0} is missing !!!", levelNumber),
                        " ",
                        "press any key to continue . . ."
                    };

                    ShowErrorMessage(ConsoleColor.White, ConsoleColor.DarkBlue, messages);
                    Console.ReadKey(true);
                }

                render.FillConsoleBackgroundColor();
                ShowStartMenu();
                ShowChoise();
            }
        }

        private void ShowPlayrResults(FinishGameMessage message)
        {
            if (message.IsGameOver)
            {
                ShowErrorMessage(ConsoleColor.Red, ConsoleColor.Blue, "GAME OVER", "", "SCORE: " + message.Score.ToString());
            }
            else
            {
                if (Data.GetNumberOfLevels() >= this.levelNumber + 1)
                {
                    ShowErrorMessage(ConsoleColor.DarkBlue, ConsoleColor.White,
                                "LEVEL: " + (this.levelNumber + 1), "", "press any key to continue. . .");
                }
                else
                {
                    ShowErrorMessage(ConsoleColor.Green, ConsoleColor.White, "YOU WIN", "", "SCORE: " + message.Score.ToString());
                }
            }
            Console.ReadKey(true);
        }

        private void ShowErrorMessage(ConsoleColor foregraundColor = ConsoleColor.White,
                                       ConsoleColor backgroundColor = ConsoleColor.DarkBlue,
                                                            params string[] messages)
        {
            render.FillConsoleBackgroundColor(backgroundColor);
            //ConsoleColor foregraundColor = ConsoleColor.White;
            // ConsoleColor backgroundColor = ConsoleColor.DarkBlue;

            int maxMessages = 6;
            int startMessageRow = (Data.GetWindowHeight() - messages.Length) / 2;

            int index = 0;
            for (int i = 0; i < messages.Length && i < maxMessages; i++)
            {
                index = i;
                int startMessageColumn = (Data.GetWindowWidth() - messages[i].Length) / 2;

                if (startMessageColumn < 1)
                {
                    startMessageColumn = 1;
                }

                render.MenuItem(startMessageRow + i, startMessageColumn, messages[i], foregraundColor, backgroundColor);
            }

            string message = "press any key to continue . . .";
            int startColumn = (Data.GetWindowWidth() - message.Length) / 2;
            render.MenuItem(startMessageRow + index + 2, startColumn, message, ConsoleColor.Yellow, backgroundColor);

            Thread.Sleep(2000);

            if (Console.KeyAvailable)
            {
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
            }

        }

        private bool IsSaveLevel()
        {
            ShowSaveMenu();

            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo();

            pressedKey = Console.ReadKey(true);

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            if (pressedKey.Key == ConsoleKey.Enter)
            {
                return true;
            }

            return false;
        }

        private void ShowSaveMenu()
        {
            render.FillConsoleBackgroundColor();
            ConsoleColor color = ConsoleColor.Green;

            render.MenuItem(rowText, colText - 10, "To SAVE level press -> ENTER <-", color);
            render.MenuItem(rowText + rowDistance, colText - 15,
                            "To continue without saving press any key...", color);
        }

        private void HideChoise()
        {
            ConsoleColor color = ConsoleColor.Red;
            render.MenuItem(choiseRow, colText - rowDistance, " ", color);
        }

        private void ShowChoise()
        {
            ConsoleColor color = ConsoleColor.Red;
            render.MenuItem(choiseRow, colText - rowDistance, "@", color);
        }

        private void ShowStartMenu()
        {
            render.FillConsoleBackgroundColor();
            ShowChoise();

            ConsoleColor color = ConsoleColor.Green;

            render.MenuItem(rowText - rowDistance, colText, "Level: " +
                            this.levelNumber.ToString().PadRight(3), color);
            render.MenuItem(rowText, colText, "Play game", color);
            render.MenuItem(rowText + rowDistance, colText, "Create level", color);
            render.MenuItem(rowText + rowDistance * 2, colText, "EXIT", color);

        }
    }
}
