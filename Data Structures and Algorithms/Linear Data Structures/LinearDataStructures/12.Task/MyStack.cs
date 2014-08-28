using System;
using System.Linq;

namespace _12.Task
{
    class MyStack<T>
    {
        const int MIN_CAPACITY = 4;
        private T[] stack;
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

        public MyStack(int capacity = MIN_CAPACITY)
        {
            if (capacity <= 0)
            {
                throw new InvalidOperationException("The intitial capacity must be positive number!");
            }
            this.capacity = capacity;
            stack = new T[capacity];
            count = 0;
        }

        public void Push(T elemToAdd)
        {
            if (count == capacity)
            {
                Array.Resize(ref stack, capacity * 2);
                capacity = capacity * 2;
            }
            stack[count++] = elemToAdd;
        }

        public T Pop()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }
            return stack[--count];
        }

        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("The stack is empty!");
            }
            return stack[count - 1];
        }

        public void Clear()
        {
            if (this.count > 0)
            {
                Array.Clear(this.stack, 0, this.count);
                this.count = 0;
            }
        }

        public override string ToString()
        {
            return String.Join(", ", stack.Take(count));
        }
    }
}
