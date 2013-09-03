using System;

class BaseXToBaseY
{
    // GetChar(15) -> 'F'
    static char GetChar(int i)
    {
        if (i >= 10) return (char)('A' + i - 10);
        else return (char)('0' + i);
    }

    // GetNumber("587", 2) -> 7
    static int GetNumber(string s, int i)
    {
        if (s[i] >= 'A') return s[i] - 'A' + 10;
        else return s[i] - '0';
    }

    // Exercise 1
    static string ConvertFromBase10ToBaseX(int d, int x)
    {
        string h = String.Empty;

        for (; d != 0; d /= x) h = GetChar(d % x) + h;

        return h;
    }

    // Exercise 2
    static int ConvertFromBaseXToBase10(string h, int x)
    {
        int d = 0;

        for (int i = h.Length - 1, p = 1; i >= 0; i--, p *= x)
            d += GetNumber(h, i) * p;

        return d;
    }

    static string ConvertFromBaseXToBaseY(string n, int x, int y)
    {
        return ConvertFromBase10ToBaseX(ConvertFromBaseXToBase10(n, x), y); // Use base 10 as proxy
    }

    static void Main()
    {
        Console.Write("Enter base to convert from (not less than 2, not bigger than 16): ");
        int firstBase = int.Parse(Console.ReadLine());
        Console.Write("Enter base to convert to (not less than 2, not bigger than 16): ");
        int secondBase = int.Parse(Console.ReadLine());
        Console.Write("Enter number in base {0} to convert: ", firstBase);
        string number = Console.ReadLine();
        string convertedNumber = ConvertFromBaseXToBaseY(number, firstBase, secondBase);
        Console.WriteLine("The converted number in base {0} is {1}", secondBase, convertedNumber);
    }
}

