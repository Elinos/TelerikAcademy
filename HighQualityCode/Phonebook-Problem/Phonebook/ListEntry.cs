namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ListEntry : IComparable<ListEntry>
    {
        private string name;
        private string nameToLower;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;

                this.nameToLower = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> Numbers { get; set; }

        public override string ToString()
        {
            StringBuilder entry = new StringBuilder();
            entry.Append('[');

            entry.Append(this.Name);
            bool singleNumber = true;
            foreach (var phone in this.Numbers)
            {
                if (singleNumber)
                {
                    entry.Append(": ");
                    singleNumber = false;
                }
                else
                {
                    entry.Append(", ");
                }

                entry.Append(phone);
            }

            entry.Append(']');
            return entry.ToString();
        }

        public int CompareTo(ListEntry other)
        {
            return this.nameToLower.CompareTo(other.nameToLower);
        }
    }
}