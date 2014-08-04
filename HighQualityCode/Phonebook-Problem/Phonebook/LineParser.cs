namespace Phonebook
{
    using System;
    using System.Linq;

    public class LineParser : ILineParser
    {
        private readonly ISanitizer sanitizer;
        private readonly IPhonebookRepository phonebookDatabase;
        private readonly IPrinter printer;
        private readonly ICommandFactory factory;

        public LineParser(ISanitizer sanitizer, IPhonebookRepository phonebookDatabase, IPrinter printer)
        {
            this.sanitizer = sanitizer;
            this.phonebookDatabase = phonebookDatabase;
            this.printer = printer;
            this.factory = new CommandFactory(sanitizer, phonebookDatabase, printer);
        }

        public void ParseLine(string inputLine)
        {
            int indexOfOpenBrace = inputLine.IndexOf('(');
            if (indexOfOpenBrace == -1)
            {
                throw new ArgumentException();
            }

            string commandName = inputLine.Substring(0, indexOfOpenBrace);
            if (!inputLine.EndsWith(")"))
            {
                throw new ArgumentException();
            }

            string unsplittedArguments = inputLine.Substring(indexOfOpenBrace + 1, inputLine.Length - indexOfOpenBrace - 2);
            string[] arguments = unsplittedArguments.Split(',');
            for (int j = 0; j < arguments.Length; j++)
            {
                arguments[j] = arguments[j].Trim();
            }

            ICommand command = this.factory.CreateCommand(commandName, arguments);
            command.Execute();
        }
    }
}