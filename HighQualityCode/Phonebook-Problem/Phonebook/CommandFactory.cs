namespace Phonebook
{
    using System;
    using System.Linq;

    public class CommandFactory : ICommandFactory
    {
        private readonly ISanitizer sanitizer;
        private readonly IPhonebookRepository phonebookDatabase;
        private readonly IPrinter printer;

        public CommandFactory(ISanitizer sanitizer, IPhonebookRepository phonebookDatabase, IPrinter printer)
        {
            this.sanitizer = sanitizer;
            this.phonebookDatabase = phonebookDatabase;
            this.printer = printer;
        }

        public ICommand CreateCommand(string commandName, string[] arguments)
        {
            ICommand command;
            if (commandName.StartsWith("AddPhone") && (arguments.Length >= 2))
            {
                command = new AddPhoneCommand(arguments, this.sanitizer, this.phonebookDatabase, this.printer);
            }
            else if ((commandName == "ChangePhone") && (arguments.Length == 2))
            {
                command = new ChangePhoneCommand(arguments, this.sanitizer, this.phonebookDatabase, this.printer);
            }
            else if ((commandName == "List") && (arguments.Length == 2))
            {
                command = new ListCommand(arguments, this.phonebookDatabase, this.printer);
            }
            else
            {
                throw new ArgumentException();
            }

            return command;
        }
    }
}