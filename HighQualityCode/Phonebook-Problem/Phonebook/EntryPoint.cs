namespace Phonebook
{
    using System;
    using System.Linq;

    internal class EntryPoint
    {
        private static void Main()
        {
            ISanitizer sanitizer = new Sanitizer();
            IPhonebookRepository phonebookDatabase = new PhonebookRepository();
            IPrinter printer = new StringBuilderPrinter();
            ILineParser lineParser = new LineParser(sanitizer, phonebookDatabase, printer);
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "End" || inputLine == null)
                {
                    break;
                }

                lineParser.ParseLine(inputLine);
            }

            Console.Write(printer.GetOutput());
        }
    }
}