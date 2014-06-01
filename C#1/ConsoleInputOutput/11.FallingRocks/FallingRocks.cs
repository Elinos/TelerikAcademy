using System;
using System.Linq;
using System.Threading;
using System.Diagnostics;

class FallingRocks
{
    static int cols = 80;
    static int rows = 20;
    static int speed = 250;
    static Stopwatch watch = new Stopwatch();
    static long gameTime = 0;
    const int speedIncInterval = 10;
    static int level = 0;
    static int score = 0;
    static string[] board = new string[rows];

    static char[] rocks = { '^', '@', '&', '+', '%', '$', '#', '!', '.', ';', '-' };
    const string dwarf = "(O)";
    static ConsoleColor dwarfColor = ConsoleColor.Green;
    static ConsoleColor rockColor = ConsoleColor.Yellow;
    static int dwarfPos = cols / 2;
    static bool isRunning = true;

    static void Move()
    {
        watch.Start();
        while (isRunning)
        {
            if (Console.KeyAvailable) // Test for keystroke
            {
                ConsoleKeyInfo inKey = Console.ReadKey(true);
                if (inKey.Key == ConsoleKey.LeftArrow && dwarfPos > 1)
                {
                    dwarfPos--;
                    if ((board[rows - 1][dwarfPos - 1] != ' ') || (board[rows - 1][dwarfPos] != ' ') || (board[rows - 1][dwarfPos + 1] != ' '))
                    {
                        isRunning = false;
                    }
                    Console.ForegroundColor = rockColor;
                    Console.SetCursorPosition(0, rows - 1);
                    Console.Write(board[rows - 1]);
                    Console.ForegroundColor = dwarfColor;
                    Console.SetCursorPosition(dwarfPos - 1, rows - 1);
                    Console.Write(dwarf);
                }
                else if (inKey.Key == ConsoleKey.RightArrow && dwarfPos < cols - 2)
                {
                    dwarfPos++;
                    if ((board[rows - 1][dwarfPos - 1] != ' ') || (board[rows - 1][dwarfPos] != ' ') || (board[rows - 1][dwarfPos + 1] != ' '))
                    {
                        isRunning = false;
                    }
                    Console.ForegroundColor = rockColor;
                    Console.SetCursorPosition(0, rows - 1);
                    Console.Write(board[rows - 1]);
                    Console.ForegroundColor = dwarfColor;
                    Console.SetCursorPosition(dwarfPos - 1, rows - 1);
                    Console.Write(dwarf);
                }
                else if (inKey.Key == ConsoleKey.Escape)
                {
                    isRunning = false;
                    return;
                }
            }
        }
    }

    static void Main()
    {
        Console.SetWindowSize(cols, rows);
        Console.SetBufferSize(cols + 1, rows + 1);
        Console.SetWindowPosition(0, 0);
        Console.Title = "Falling Rocks";

        for (int i = 0; i < rows; i++)
        {
            board[i] = new String(' ', cols);
        }

        Console.CursorVisible = false;

        Console.ForegroundColor = dwarfColor;
        Console.SetCursorPosition(dwarfPos - 1, rows - 1);
        Console.Write(dwarf);
        Random rng = new Random((int)DateTime.Now.Millisecond);

        Thread movement = new Thread(new ThreadStart(Move));
        movement.Start();

        while (isRunning)
        {
            for (int cRow = rows - 1; cRow > 0; cRow--)
            {
                board[cRow] = board[cRow - 1];
                Console.ForegroundColor = rockColor;
                Console.SetCursorPosition(0, cRow);
                Console.Write(board[cRow]);
                if (cRow == rows - 1)
                {
                    if ((board[rows - 1][dwarfPos - 1] != ' ') || (board[rows - 1][dwarfPos] != ' ') || (board[rows - 1][dwarfPos + 1] != ' '))
                    {
                        isRunning = false;
                    }
                    Console.ForegroundColor = dwarfColor;
                    Console.SetCursorPosition(dwarfPos - 1, rows - 1);
                    Console.Write(dwarf);
                }
            }

            int numRocks = rng.Next(cols / 20);
            board[0] = new String(' ', cols);
            for (int i = 0; i < numRocks; i++)
            {
                int colNum = rng.Next(0, cols);
                char[] newRow = board[0].ToCharArray();
                newRow[colNum] = rocks[rng.Next(0, 11)];
                board[0] = new String(newRow);
                Console.ForegroundColor = rockColor;
                Console.SetCursorPosition(0, 0);
                Console.Write(board[0]);
            }

            score += 10;
            gameTime = watch.ElapsedMilliseconds / 1000;
            level = (int)Math.Floor((decimal)(gameTime / speedIncInterval)) * 20;
            Thread.Sleep(speed - level);
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(cols / 2 - 5, rows / 2 - 1);
        Console.WriteLine("Game over!");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition((cols - score.ToString().Length - 7) / 2, rows / 2);
        Console.WriteLine("Score: " + score);
        Console.ReadLine();
    }
}
