using System;
using System.Linq;

namespace TaskOne
{
    class TaskOne
    {
        static void Main(string[] args)
        {
            var tree = ReadInput();
            var root = tree.FindRoot();
            Console.WriteLine(new String('-', 50));
            Console.WriteLine("Root: {0}", root.Value);

            Console.WriteLine(new String('-', 50));
            var leafs = tree.FindLeafs();
            foreach (var leaf in leafs)
            {
                Console.Write("Leaf: ");
                Console.WriteLine(leaf.Value);
            }

            Console.WriteLine(new String('-', 50));
            var middles = tree.FindMiddles();
            foreach (var middle in middles)
            {
                Console.Write("Middle: ");
                Console.WriteLine(middle.Value);
            }

            Console.WriteLine(new String('-', 50));
            var longestPath = tree.FindLongestPath(root);
            Console.WriteLine("The longest path is : {0}", longestPath);
        }

        private static Tree<int> ReadInput()
        {
            var tree = new Tree<int>();
            var numberOfNodes = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                var line = Console.ReadLine();
                var splittedLine = line.Split().Select(int.Parse).ToArray();
                var nodeValue = splittedLine[0];
                tree.AddNode(nodeValue);
                var childValue = splittedLine[1];
                tree.AddChildren(childValue, nodeValue);
            }

            return tree;
        }
    }
}
