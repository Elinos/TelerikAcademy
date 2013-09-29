using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class FTML
{
    static readonly string[] stringsToReverse = new string[10];
    static bool inDelTag = false;
    static bool inRevTag = false;
    static int revTags = 0;
    static int delTags = 0;

    static void Main()
    {
        if (File.Exists(@"..\..\input.txt"))
            Console.SetIn(new StreamReader(@"..\..\input.txt"));
        StringBuilder text = new StringBuilder();
        StringBuilder output = new StringBuilder();
        Stack<string> tags = new Stack<string>();

        int lines = int.Parse(Console.ReadLine());
        ReadText(lines, text);
        ReadChar(text, tags, output);
        Console.Write(output);
    }

    private static void ReadChar(StringBuilder text, Stack<string> tags, StringBuilder output)
    {
        for (int c = 0; c < text.Length; c++)
        {
            char currentSymbol = text[c];
            if (currentSymbol == '<')
            {
                string tag = ReadTag(text, c);
                if (tag[0] != '/')
                {
                    tags.Push(tag);
                    c += tag.Length + 1;
                    if (tag == "del")
                    {
                        inDelTag = true;
                        delTags++;
                    }
                    else if (tag == "rev")
                    {
                        inRevTag = true;
                        revTags++;
                    }
                }
                else
                {
                    c += tag.Length + 1;
                    tags.Pop();
                    if (tag == "/del")
                    {
                        delTags--;
                        if (delTags == 0)
                            inDelTag = false;
                    }
                    else if (tag == "/rev")
                    {
                        revTags--;
                        ReverseAndApplyTags(output, tags);
                        inRevTag = false;
                    }
                }
            }
            else
            {
                if (tags.Count != 0)
                    ApplyTags(tags, currentSymbol, output);
                else
                    output.Append(currentSymbol);
            }
        }
    }

    private static void ReadText(int lines, StringBuilder text)
    {
        for (int i = 0; i < lines; i++)
        {
            string currentLine = Console.ReadLine();
            text.Append(currentLine);
            text.Append("\n");
        }
    }

    private static void ReverseAndApplyTags(StringBuilder output, Stack<string> tags)
    {
        string rev = String.Empty;
        int firstHit = 0;
        for (int i = stringsToReverse.Length - 1; i >= 1; i--)
        {
            if (firstHit == 0 && stringsToReverse[i] != null)
                firstHit = i;
        }
        if (firstHit > 0)
        {
            string reversed = stringsToReverse[firstHit];
            reversed = ReverseString(reversed);
            rev = string.Format("{0}{1}", reversed, rev);
            foreach (char symbol in rev)
                ApplyTags(tags, symbol, output);
            stringsToReverse[firstHit] = null;
        }
    }

    private static void ApplyTags(Stack<string> tags, char currentSymbol, StringBuilder output)
    {
        Stack<string> currentTags = new Stack<string>(tags.Reverse());
        char toAppend = currentSymbol;

        while (currentTags.Count != 0)
        {
            string curTag = currentTags.Pop();
            if (curTag == "upper" && !inDelTag)
                toAppend = Char.ToUpper(toAppend);
            else if (curTag == "lower" && !inDelTag)
                toAppend = Char.ToLower(toAppend);
            else if (curTag == "toggle" && !inDelTag)
                toAppend = Char.IsUpper(toAppend) ? Char.ToLower(toAppend) : Char.ToUpper(toAppend);
            else if (curTag == "rev" && !inDelTag)
            {
                stringsToReverse[revTags] += toAppend;
                return;
            }
        }
        if (!inDelTag)
            output.Append(toAppend);
    }

    private static string ReadTag(StringBuilder currentLine, int index)
    {
        string tag = String.Empty;
        index++;
        char nextSymbol = currentLine[index];
        while (nextSymbol != '>')
        {
            tag += nextSymbol;
            index++;
            nextSymbol = currentLine[index];
        }
        return tag;
    }

    private static string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}