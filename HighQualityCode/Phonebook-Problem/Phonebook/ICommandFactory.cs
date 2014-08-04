namespace Phonebook
{
    using System;
    using System.Linq;

    public interface ICommandFactory
    {
        ICommand CreateCommand(string command, string[] arguments);
    }
}