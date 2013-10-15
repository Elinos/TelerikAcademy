using System;
using System.Text;

static class StringBuilderSubstring
{
    public static StringBuilder Substring(this StringBuilder str, int index, int length)
    {
        return new StringBuilder(str.ToString(), index, length, length);
    }

    static void Main()
    {
        StringBuilder pesho = new StringBuilder("pesho");
        pesho = pesho.Substring(2, 3);
        Console.WriteLine(pesho);
    }
}
