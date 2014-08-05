namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly OrderedSet<ListEntry> sorted = new OrderedSet<ListEntry>();
        private readonly Dictionary<string, ListEntry> dict = new Dictionary<string, ListEntry>();
        private readonly MultiDictionary<string, ListEntry> multidict = new MultiDictionary<string, ListEntry>(false);

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            string nameToLower = name.ToLowerInvariant();
            ListEntry entry;
            bool isNewEntry = !this.dict.TryGetValue(nameToLower, out entry);
            if (isNewEntry)
            {
                entry = new ListEntry();
                entry.Name = name;
                entry.Numbers = new SortedSet<string>();
                this.dict.Add(nameToLower, entry);

                this.sorted.Add(entry);
            }

            foreach (var num in nums)
            {
                this.multidict.Add(num, entry);
            }

            entry.Numbers.UnionWith(nums);
            return isNewEntry;
        }

        public int ChangePhone(string oldent, string newent)
        {
            var found = this.multidict[oldent].ToList();
            foreach (var entry in found)
            {
                entry.Numbers.Remove(oldent);
                this.multidict.Remove(oldent, entry);

                entry.Numbers.Add(newent);
                this.multidict.Add(newent, entry);
            }

            return found.Count;
        }

        public ListEntry[] ListEntries(int first, int num)
        {
            if (first < 0 || first + num > this.dict.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid range!");
            }

            ListEntry[] list = new ListEntry[num];

            for (int i = first; i <= first + num - 1; i++)
            {
                ListEntry entry = this.sorted[i];
                list[i - first] = entry;
            }

            return list;
        }
    }
}