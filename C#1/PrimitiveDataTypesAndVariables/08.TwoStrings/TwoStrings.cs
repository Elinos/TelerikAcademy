using System;

class TwoStrings
{
    static void Main()
    {
        string sentence = "The \"use\" of quotations causes difficulties.";
        string sameSentence = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine("The sentence using \\\'s:\n{0}\n\nAnd the same sentence using quoted string:\n{1}", sentence, sameSentence);
    }
}
