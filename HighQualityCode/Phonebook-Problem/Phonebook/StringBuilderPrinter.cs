namespace Phonebook
{
    using System;
    using System.Linq;
    using System.Text;

    public class StringBuilderPrinter : IPrinter
    {
        private readonly StringBuilder output = new StringBuilder();

        public void Print(string text)
        {
            this.output.AppendLine(text);
        }

        public string GetOutput()
        {
            return this.output.ToString();
        }
    }
}