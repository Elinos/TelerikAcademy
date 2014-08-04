namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository
    {
        private readonly OrderedSet<ListEntries> sorted = new OrderedSet<ListEntries>();
        private readonly Dictionary<string, ListEntries> dict = new Dictionary<string, ListEntries>();
        private readonly MultiDictionary<string, ListEntries> multidict = new MultiDictionary<string, ListEntries>(false);

        public bool AddPhone(string name, IEnumerable<string> nums)
        {
            string nameToLower = name.ToLowerInvariant();
            ListEntries entry;
            bool isNewEntry = !this.dict.TryGetValue(nameToLower, out entry);
            if (isNewEntry)
            {
                entry = new ListEntries();
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

        public ListEntries[] ListEntries(int first, int num)
        {
            if (first < 0 || first + num > this.dict.Count)
            {
                Console.WriteLine("Invalid start index or count.");
            }

            ListEntries[] list = new ListEntries[num];

            for (int i = first; i <= first + num - 1; i++)
            {
                ListEntries entry = this.sorted[i];
                list[i - first] = entry;
            }

            return list;
        }
    }
}