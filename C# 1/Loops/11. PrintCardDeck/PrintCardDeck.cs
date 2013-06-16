using System;
using System.Text;

class PrintCardDeck
{
    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.White; 
        Console.Clear();
        string[] faces = { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
        StringBuilder cardName = new StringBuilder();

        foreach (string face in faces)
        {
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        cardName.Append(face);
                        cardName.Append(" of Diamonds");
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Black;
                        cardName.Append(face);
                        cardName.Append(" of Clubs");
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Red;
                        cardName.Append(face);
                        cardName.Append(" of Hearts");
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Black;
                        cardName.Append(face);
                        cardName.Append(" of Spades");
                        break;
                    default:
                        break;
                }
                Console.Write(cardName.ToString().PadRight(20));
                cardName.Clear();
            }
        }
    }
}
