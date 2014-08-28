using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.Task
{
    public class LinkedQueue<T>
    {
        private LinkedList<T> linkedQueue = new LinkedList<T>();

        public T Dequeue()
        {
            if (linkedQueue.First == null)
            {
                throw new InvalidOperationException();
            }
            T firstItem = linkedQueue.First.Value;
            linkedQueue.RemoveFirst();

            return firstItem;
        }

        public void Enqueue(T item)
        {
            linkedQueue.AddLast(item);
        }

        public T Peek()
        {
            return linkedQueue.Last.Value;
        }

        public void Clear()
        {
            linkedQueue.Clear();
        }

        public int Count
        {
            get
            {
                return linkedQueue.Count;
            }
        }
    }
}
