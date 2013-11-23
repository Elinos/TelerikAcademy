using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleSity
{
    public static class LevelEditorEngine
    {
        private static int rowsByDimention;
        private static int colsByDimention;
        private static int levelRow;
        private static int levelCol;
        private static int minRow;
        private static int maxRow;
        private static int minCol;
        private static int maxCol;
        private static int currentElementRow;
        private static int currenElementCol;
        private static int changeDistance;
        private static int eagleRowLevelCordinate;
        private static int eagleColLevelCordinate;

        private static Element element;
        private static ElementType currentElementType;
        private static ConsoleRender render;
        private static bool isSave;
        private static bool savePressed;
        private static bool isExit;

        private static Element[,] elements;

        public static Element[,] CreateLevel()
        {
            Initialisation();

            elements = new Element[rowsByDimention, colsByDimention];

            // insert eagle
            eagleRowLevelCordinate = rowsByDimention - 1;
            eagleColLevelCordinate = (colsByDimention - 1) / 2;
            int eagleRow = eagleRowLevelCordinate * changeDistance + minRow;
            int eagleCol = eagleColLevelCordinate * changeDistance;
            
            Element eagle = new Element(ElementType.Eagle, eagleRow, eagleCol);
            elements[eagleRowLevelCordinate, eagleColLevelCordinate] = eagle;
            render.DrawElement(eagle);


            return Create();
        }

        private static Element[,] Create()
        {
            while (true)
            {
                TakeAction();

                Save();

                if (isExit)
                {
                    break;
                }

                Thread.Sleep(10);
            }

            return elements;
        }

        private static void ShowElement()
        {
            render.DrawElement(element);
        }

        private static void Save()
        {
            if (isSave)
            {
                if (element.Type == ElementType.Empty)
                {
                    elements[levelRow, levelCol] = null;
                }
                else
                {
                    elements[levelRow, levelCol] = element;
                }

                savePressed = true;
            }
        }

        private static void CreateElement()
        {
            element = new Element(currentElementType, currentElementRow, currenElementCol);
            ShowElement();
        }

        private static void TakeAction()
        {
            isSave = false;
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo();

            if (Console.KeyAvailable)
            {
                int newLevelRow = levelRow;
                int newLevelCol = levelCol;

                pressedKey = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    newLevelRow--;
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    newLevelRow++;
                }
                else if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    newLevelCol--;
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    newLevelCol++;
                }
                else if (pressedKey.Key == ConsoleKey.A)
                {
                    currentElementType++;

                    if (currentElementType == ElementType.Eagle)
                    {
                        currentElementType++;
                    }

                    if (currentElementType > ElementType.Empty)
                    {
                        currentElementType = ElementType.Wother;
                    }

                    CreateElement();
                }
                else if (pressedKey.Key == ConsoleKey.S)
                {
                    currentElementType--;

                    if (currentElementType == ElementType.Eagle)
                    {
                        currentElementType--;
                    }

                    if (currentElementType < 0)
                    {
                        currentElementType = ElementType.Empty;
                    }

                    CreateElement();
                }
                else if (pressedKey.Key == ConsoleKey.Spacebar)
                {
                    isSave = true;
                }
                else if (pressedKey.Key == ConsoleKey.Escape)
                {
                    isExit = true;
                }

                IsValidCordinats(newLevelRow, newLevelCol);
            }
        }

        private static void IsValidCordinats(int newLevelRow, int newLevelCol)
        {
            int newRow = newLevelRow * changeDistance + minRow;
            int newCol = newLevelCol * changeDistance + minCol;

            if (newRow >= minRow && newRow + changeDistance <= maxRow &&
                newCol >= minCol && newCol + changeDistance <= maxCol)
            {

                //if (newLevelRow == 15 && newLevelCol == 17)
                if (newLevelRow == eagleRowLevelCordinate && newLevelCol == eagleColLevelCordinate)
                {
                    return;
                }

                if (savePressed)
                {
                    savePressed = false;
                }
                else
                {
                    if (elements[levelRow, levelCol] != null)
                    {
                        render.DrawElement(elements[levelRow, levelCol]);
                    }
                    else
                    {
                        render.DeleteElement(element);
                    }
                }

                levelRow = newLevelRow;
                levelCol = newLevelCol;

                currentElementRow = newRow;
                currenElementCol = newCol;


                CreateElement();
                ShowElement();
            }
        }

        private static void Initialisation()
        {
            int dimention = Data.GetElementDimention();
            int height = Data.GetWindowHeight();

            minRow = 2;
            rowsByDimention = (height - minRow) / dimention;
            colsByDimention = (Data.GetWindowWidth() - 1) / dimention;


            maxRow = height;
            minCol = 0;
            maxCol = Data.GetWindowWidth() - 1;

            currentElementRow = minRow;
            currenElementCol = minCol;

            isExit = false;

            currentElementType = ElementType.Empty;

            changeDistance = Data.GetElementDimention();

            render = new ConsoleRender(Data.GetWindowWidth(), height);

            currentElementType = ElementType.Braket;
            element = new Element(currentElementType, minRow, minCol);
            ShowElement();
        }
    }
}
