using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskOne
{
    class Tree<T>
    {
        public Dictionary<T, Node<T>> Members;

        public Tree()
        {
            this.Members = new Dictionary<T, Node<T>>();
        }

        public List<Node<T>> FindLeafs()
        {
            var leafs = new List<Node<T>>();
            foreach (var node in this.Members)
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
            foreach (var node in this.Members)
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
            foreach (var node in this.Members)
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
    }
}
