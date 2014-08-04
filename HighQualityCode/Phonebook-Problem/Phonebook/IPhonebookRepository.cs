namespace Phonebook
{
    using System.Collections.Generic;

    public interface IPhonebookRepository
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        ListEntries[] ListEntries(int startIndex, int count);
    }
}