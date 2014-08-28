using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskOne
{
    public class Node<T>
    {
        public T Value { get; set; }
        public List<Node<T>> Children { get; set; }
        public bool HasParent { get; set; }

        public bool IsLeaf { get; set; }

        public bool IsRoot { get; set; }

        public Node(T value)
        {
            this.Value = value;
            this.Children = new List<Node<T>>();
        }

        public void PrintNodeTree()
        {
            this.Print(String.Empty, true);
        }

        private void Print(string prefix, bool isTail)
        {
            Console.WriteLine(prefix + (isTail ? "└── " : "├── ") + this.Value);
            for (int i = 0; i < this.Children.Count - 1; i++)
                this.Children[i].Print(prefix + (isTail ? "    " : "│   "), false);

            if (this.Children.Count >= 1)
                this.Children[this.Children.Count - 1].Print(prefix + (isTail ? "    " : "│   "), true);
        }
    }
}
