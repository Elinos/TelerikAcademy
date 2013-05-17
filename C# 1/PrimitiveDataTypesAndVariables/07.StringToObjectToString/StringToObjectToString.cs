using System;

class StringToObjectToString
{
    static void Main()
    {
        string firstWord = "Hello";
        string secondWord = "World";
        object firstPlusSecondWord = firstWord + " " + secondWord;
        string objectToString = firstPlusSecondWord.ToString();
        Console.WriteLine(firstPlusSecondWord);
    }
}

