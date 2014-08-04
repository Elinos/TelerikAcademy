namespace Phonebook
{
    using System;
    using System.Linq;

    public interface IPrinter
    {
        void Print(string text);

        string GetOutput();
    }
}