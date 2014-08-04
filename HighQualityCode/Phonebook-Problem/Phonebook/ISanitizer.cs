namespace Phonebook
{
    using System;
    using System.Linq;

    public interface ISanitizer
    {
        string Sanitize(string number);
    }
}