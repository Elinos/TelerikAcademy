namespace Phonebook
{
    using System;
    using System.Linq;
    using System.Text;

    public class Sanitizer : ISanitizer
    {
        private const string Code = "+359";

        public string Sanitize(string number)
        {
            StringBuilder sanitezedNumber = new StringBuilder();

            foreach (char character in number)
            {
                if (char.IsDigit(character) || (character == '+'))
                {
                    sanitezedNumber.Append(character);
                }
            }

            if (sanitezedNumber.Length >= 2 && sanitezedNumber[0] == '0' && sanitezedNumber[1] == '0')
            {
                sanitezedNumber.Remove(0, 1);
                sanitezedNumber[0] = '+';
            }

            while (sanitezedNumber.Length > 0 && sanitezedNumber[0] == '0')
            {
                sanitezedNumber.Remove(0, 1);
            }

            if (sanitezedNumber.Length > 0 && sanitezedNumber[0] != '+')
            {
                sanitezedNumber.Insert(0, Code);
            }

            return sanitezedNumber.ToString();
        }
    }
}