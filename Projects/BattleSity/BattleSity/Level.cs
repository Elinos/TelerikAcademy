using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleSity
{
    public class Level
    {
        public Element[,] CurrentLevel { get; set; }
        public Level(string fileName)
        {

            //параметърът ще е името на файла, от който зареждаме

            string[] lines = System.IO.File.ReadAllLines(fileName);
            CurrentLevel = new Element[40, 10];

            for (int currentRow = 0; currentRow < lines.Length; currentRow += 3)
            {
                string line = lines[currentRow];
                for (int currentCol = 0; currentCol < line.Length; currentCol += 3)
                {
                    char symbol = line[currentCol];
                    ElementType currentElementType = ElementType.Wother;

                    switch (symbol)
                    {
                        case '~':
                            currentElementType = ElementType.Wother;
                            break;

                        case '#':
                            currentElementType = ElementType.Steel;
                            break;
                        case 'W':
                            currentElementType = ElementType.Braket;
                            break;
                        case 'e':
                            currentElementType = ElementType.Eagle;
                            break;
                        case ' ':
                            currentElementType = ElementType.Empty;
                            break;
                        default:
                            break;
                    }

                    Element currentElement = new Element(currentElementType, currentRow % 3, currentCol % 3);
                    // % 3 защото всеки символ на картата е таблица 3 х 3
                    CurrentLevel[currentCol % 3, currentRow % 3] = currentElement;
                    currentCol++;
                }
                currentRow++;
            }
        }
    }
}
