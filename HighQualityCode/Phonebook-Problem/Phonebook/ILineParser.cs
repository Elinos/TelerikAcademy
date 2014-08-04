namespace Phonebook
{
    using System;
    using System.Linq;

    public interface ILineParser
    {
        void ParseLine(string inputLine);
    }
}