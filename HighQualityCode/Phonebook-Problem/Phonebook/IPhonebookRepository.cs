namespace Phonebook
{
    using System.Collections.Generic;

    /// <summary>
    /// Repository for storing phonebook entries
    /// </summary>
    public interface IPhonebookRepository
    {
        /// <summary>
        /// Adds new entry with a given name and phone numbers.
        /// Check if name already exist and merge it if it's existing member.
        /// </summary>
        /// <param name="name">The name of the entry</param>
        /// <param name="phoneNumbers">Array of cannonical phone numbers</param>
        /// <returns></returns>
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        /// <summary>
        /// Search for existing phone number and change it.
        /// </summary>
        /// <param name="oldPhoneNumber">The existing phone number.</param>
        /// <param name="newPhoneNumber">The new phone number that we want to change it to.</param>
        /// <returns></returns>
        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        /// <summary>
        /// List phone entries based on the specified page nuber and total count of numbers that we want to be shown,
        /// printed in the following form: "[name: phone1, phone2, …]", 
        /// The numbers are first sorded by name.
        /// The name appear in the same casing as when it was first added to the phonebook
        /// In case the start index is invalid or the count is invalid, it throws ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="startIndex">The page number(zero based)</param>
        /// <param name="count">Total count of numbers to be shown</param>
        /// <returns></returns>
        ListEntry[] ListEntries(int startIndex, int count);
    }
}