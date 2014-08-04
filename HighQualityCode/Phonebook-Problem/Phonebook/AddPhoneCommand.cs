namespace Phonebook
{
    using System;
    using System.Linq;

    public class AddPhoneCommand : ICommand
    {
        private readonly string[] arguments;
        private readonly ISanitizer sanitizer;
        private readonly IPhonebookRepository phonebookDatabase;
        private readonly IPrinter printer;

        public AddPhoneCommand(string[] arguments, ISanitizer sanitizer, IPhonebookRepository phonebookDatabase, IPrinter printer)
        {
            this.phonebookDatabase = phonebookDatabase;
            this.sanitizer = sanitizer;
            this.arguments = arguments;
            this.printer = printer;
        }

        public void Execute()
        {
            string name = this.arguments[0];
            var numbers = this.arguments.Skip(1).ToList();
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] = this.sanitizer.Sanitize(numbers[i]);
            }

            bool isNewEntry = this.phonebookDatabase.AddPhone(name, numbers);

            if (isNewEntry)
            {
                this.printer.Print("Phone entry created");
            }
            else
            {
                this.printer.Print("Phone entry merged");
            }
        }
    }
}