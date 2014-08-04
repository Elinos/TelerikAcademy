namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListCommand : ICommand
    {
        private readonly string[] arguments;
        private readonly IPhonebookRepository phonebookDatabase;
        private readonly IPrinter printer;

        public ListCommand(string[] arguments, IPhonebookRepository phonebookDatabase, IPrinter printer)
        {
            this.phonebookDatabase = phonebookDatabase;
            this.arguments = arguments;
            this.printer = printer;
        }

        public void Execute()
        {
            try
            {
                IEnumerable<ListEntries> entries = this.phonebookDatabase.ListEntries(
                    int.Parse(this.arguments[0]),
                    int.Parse(this.arguments[1]));
                foreach (var entry in entries)
                {
                    this.printer.Print(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                this.printer.Print("Invalid range");
            }
        }
    }
}