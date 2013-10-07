using System;
using System.Linq;

namespace GenericList
{
    class GenericList<T>
    where T : IComparable
    {
        const int MIN_CAPACITY = 4;
        private T[] list;
        private int capacity;
        private int count;

        public int Count
        {
            get { return count; }
        }

        public int Capacity
        {
            get { return capacity; }
        }

        public GenericList(int capacity = MIN_CAPACITY)
        {
            // TODO: Validate index

            this.capacity = capacity;
            list = new T[capacity];
            count = 0;
        }

        public T this[int index]
        {
            // TODO: Validate index

            get { return list[index]; }
            set { list[index] = value; }
        }

        public void Add(T elemToAdd)
        {
            // TODO: Validate index
            if (count == capacity)
            {
                Array.Resize(ref list, capacity * 2);
            }
            list[count++] = elemToAdd;
        }

        public void RemoveAt(int index)
        {
            // TODO: Validate index

            for (int i = index + 1; i < count; i++)
            {
                list[i - 1] = list[i];
            }
            list[--count] = default(T);
        }

        public void InsertAt(T elemToAdd, int index)
        {
            if (index > count || index < 0)
            {
                throw new IndexOutOfRangeException("Index is out of range! Must be between 0 and " + count);
            }

            if (count == capacity)
            {
                Array.Resize(ref list, capacity * 2);
            }

            for (int i = count + 1; i > index; i--)
            {
                list[i] = list[i - 1];
            }
            list[index] = elemToAdd;
            count++;
        }

        public void Clear()
        {
            if (this.count > 0)
            {
                Array.Clear(this.list, 0, this.count);
                this.count = 0;
            }
        }

        public int FindIndex(T elemToFind)
        {
            return Array.IndexOf(list, elemToFind);
        }

        public T Min()
        {
            return list.Take(count).Min();
        }

        public T Max()
        {
            return list.Take(count).Max();
        }

        public override string ToString()
        {
            return String.Join(", ", list.Take(count));
        }
    }
}
