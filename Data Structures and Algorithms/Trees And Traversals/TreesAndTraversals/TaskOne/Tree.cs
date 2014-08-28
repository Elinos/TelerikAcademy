using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskOne
{
    class Tree<T>
    {
        private Dictionary<T, Node<T>> members;

        public Tree()
        {
            this.members = new Dictionary<T, Node<T>>();
        }

        public void AddNode(T value)
        {
            if (!this.members.ContainsKey(value))
            {
                var newNode = new Node<T>(value);
                this.members[value] = newNode;
            }
        }

        public void AddChildren(T childValue, T parentValue)
        {
            if (!this.members.ContainsKey(childValue))
            {
                var newChild = new Node<T>(childValue);
                newChild.HasParent = true;
                this.members[childValue] = newChild;
            }

            this.members[childValue].HasParent = true;
            this.members[parentValue].Children.Add(this.members[childValue]);
        }

        public List<Node<T>> FindLeafs()
        {
            var leafs = new List<Node<T>>();
            foreach (var node in this.members)
            {
                if (node.Value.Children.Count == 0)
                {
                    leafs.Add(node.Value);
                    node.Value.IsLeaf = true;
                }
            }

            return leafs;
        }

        public List<Node<T>> FindMiddles()
        {
            var middles = new List<Node<T>>();
            foreach (var node in this.members)
            {
                if (node.Value.Children.Count > 0 && node.Value.HasParent == true)
                {
                    middles.Add(node.Value);
                }
            }

            return middles;
        }

        public Node<T> FindRoot()
        {
            foreach (var node in this.members)
            {
                if (node.Value.HasParent == false)
                {
                    node.Value.IsRoot = true;
                    return node.Value;
                }
            }

            throw new InvalidOperationException("There is no root!");
        }

        public int FindLongestPath(Node<T> node)
        {
            int longestPath = 0;
            if (node.IsLeaf)
            {
                return 0;
            }
            else
            {
                foreach (var child in node.Children)
                {
                    int pathFromChild = FindLongestPath(child);
                    if (longestPath < 1 + pathFromChild)
                    {
                        longestPath = 1 + pathFromChild;
                    }
                }
            }
            return longestPath;
        }

        public void PrintTree()
        {
            Console.WriteLine("Tree");
            FindRoot().PrintNodeTree();
        }
    }
}
