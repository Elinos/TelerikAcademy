namespace Phonebook
{
    using System;
    using System.Linq;

    public class ChangePhoneCommand : ICommand
    {
        private readonly string[] arguments;
        private readonly ISanitizer sanitizer;
        private readonly IPhonebookRepository phonebookDatabase;
        private readonly IPrinter printer;

        public ChangePhoneCommand(string[] arguments, ISanitizer sanitizer, IPhonebookRepository phonebookDatabase, IPrinter printer)
        {
            this.phonebookDatabase = phonebookDatabase;
            this.sanitizer = sanitizer;
            this.arguments = arguments;
            this.printer = printer;
        }

        public void Execute()
        {
            var oldNumber = this.arguments[0];
            var newNumber = this.arguments[1];
            var sanitizedOldNumber = this.sanitizer.Sanitize(oldNumber);
            var sanitizedNewNumber = this.sanitizer.Sanitize(newNumber);
            var countOfChangedNumbers = this.phonebookDatabase.ChangePhone(sanitizedOldNumber, sanitizedNewNumber);
            var sentenceToPrint = string.Format("{0} numbers changed", countOfChangedNumbers);
            this.printer.Print(sentenceToPrint);
        }
    }
}