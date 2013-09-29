using System;
using System.IO;
using System.Linq;

class KukataIsDancing
{
    static void Main()
    {
        if (File.Exists(@"..\..\input.txt"))
            Console.SetIn(new StreamReader(@"..\..\input.txt"));
        string[,] matrix = new string[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if ((i == 0 || i == 2) && (j == 0 || j == 2))
                {
                    matrix[i, j] = "RED";
                }
                else if (i == 1 && j == 1)
                {
                    matrix[i, j] = "GREEN";
                }
                else
                {
                    matrix[i, j] = "BLUE";
                }
            }
        }
        string[] directions = { "up", "left", "down", "right" };
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int currentWidth = 1;
            int currentHeight = 1;
            string currentDirection = "up";
            string commands = Console.ReadLine();
            for (int c = 0; c < commands.Length; c++)
            {

                char command = commands[c];
                int index;

                if (command == 'L')
                {
                    index = Array.IndexOf(directions, currentDirection);
                    currentDirection = directions[(index + 1) % 4];
                }
                else if (command == 'R')
                {
                    index = Array.IndexOf(directions, currentDirection);
                    currentDirection = currentDirection == "up" ? directions[3] : directions[(index - 1) % 4];
                }
                else if (command == 'W')
                {
                    currentHeight = Move(currentWidth, currentHeight, currentDirection)[0];
                    currentWidth = Move(currentWidth, currentHeight, currentDirection)[1];
                }

            }
            Console.WriteLine(matrix[currentHeight, currentWidth]);
        }
    }

    private static int[] Move(int currentWidth, int currentHeight, string currentDirection)
    {

        if (currentDirection == "up")
        {
            currentHeight = currentHeight == 0 ? 2 : (currentHeight - 1) % 3;
        }
        else if (currentDirection == "left")
        {
            currentWidth = currentWidth == 0 ? 2 : (currentWidth - 1) % 3;
        }
        else if (currentDirection == "down")
        {
            currentHeight = (currentHeight + 1) % 3;
        }
        else if (currentDirection == "right")
        {
            currentWidth = (currentWidth + 1) % 3;
        }
        int[] result = { currentHeight, currentWidth };
        return result;
    }
}

