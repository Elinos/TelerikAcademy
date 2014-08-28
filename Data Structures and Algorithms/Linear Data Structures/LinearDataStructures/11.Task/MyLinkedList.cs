using System;
using System.Linq;

namespace _11.Task
{
    class MyLinkedList<T> : System.Collections.Generic.IEnumerable<T>
    {
        private ListItem<T> FirstItem { get; set; }
        public void AddFirst(T value)
        {
            var newNode = new ListItem<T>()
            {
                Value = value
            };

            if (this.FirstItem == null)
            {
                this.FirstItem = newNode;
            }
            else
            {
                var oldFirstItem = this.FirstItem;
                this.FirstItem = newNode;
                this.FirstItem.NextItem = oldFirstItem;
            }
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            var node = this.FirstItem;
            while (node != null)
            {
                yield return node.Value;
                node = node.NextItem;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
