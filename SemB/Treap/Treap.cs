using SemB.Generator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SemB.Treap
{

    public class Treap<TK, TP> : ITreap<TK, TP> where TK : IComparable<TK> where TP : IComparable<TP>
    {
        private class Node
        {
            public TK Key { get; set; }
            public TP Priority { get; private set; }
            public Node Left;
            public Node Right;

            public Node(TK key, TP priority)
            {
                Key = key;
                Priority = priority;
            }
            public override string ToString()
            {
                return $"{Left?.PrintNode()} <- {Key}({Priority}) -> {Right?.PrintNode()}";
            }

            public string PrintNode()
            {
                return $"{Key}({Priority})";
            }
        }

        private Node root;
        private IPriorityGenerator<TP> priorityGenerator;
        private int count;

        public Treap(IPriorityGenerator<TP> priorityGenerator)
        {
            this.priorityGenerator = priorityGenerator;
            this.root = null;
            this.count = 0;
        }

        public int Count() => count;

        public void Add(TK key)
        {
            if (priorityGenerator != null)
                root = Insert(ref root, key, priorityGenerator.Next());
            else
                throw new InvalidOperationException("Priority generator is not loaded.");
        }

        private Node Insert(ref Node node, TK key, TP priority)
        {
            if (node == null)
            {
                count++;
                return node = new Node(key, priority);
            }

            int cmp = key.CompareTo(node.Key);
            if (cmp < 0)
            {
                node.Left = Insert(ref node.Left, key, priority);
                if (node.Left.Priority.CompareTo(node.Priority) < 0)
                    node = RotateRight(node);
            }
            else if (cmp > 0)
            {
                node.Right = Insert(ref node.Right, key, priority);
                if (node.Right.Priority.CompareTo(node.Priority) < 0)
                    node = RotateLeft(node);
            }
            return node;
        }

        public bool Remove(TK key)
        {
            int initialCount = count;
            root = Delete(root, key);
            return count < initialCount;
        }

        private Node Delete(Node node, TK key)
        {
            if (node == null) return null;

            int cmp = key.CompareTo(node.Key);
            if (cmp < 0)
                node.Left = Delete(node.Left, key);
            else if (cmp > 0)
                node.Right = Delete(node.Right, key);
            else
            {
                if (node.Left == null || node.Right == null)
                {
                    count--;
                    return node.Left ?? node.Right;
                }

                if (node.Left.Priority.CompareTo(node.Right.Priority) < 0)
                {
                    node = RotateLeft(node);
                    node.Left = Delete(node.Left, key);
                }
                else
                {
                    node = RotateRight(node);
                    node.Right = Delete(node.Right, key);
                }
            }
            return node;
        }

        private Node RotateRight(Node node)
        {
            Node left = node.Left;
            node.Left = left.Right;
            left.Right = node;
            return left;
        }

        private Node RotateLeft(Node node)
        {
            Node right = node.Right;
            node.Right = right.Left;
            right.Left = node;
            return right;
        }

        public void Clear()
        {
            root = null;
            count = 0;
        }

        public object Find(TK key)
        {
            Node node = root;
            while (node != null)
            {
                int cmp = key.CompareTo(node.Key);
                if (cmp < 0) node = node.Left;
                else if (cmp > 0) node = node.Right;
                else return node;
            }
            return null;
        }

        public int Height()
        {
            return Height(root);
        }

        private int Height(Node node)
        {
            if (node == null)
                return 0;
            int leftHeight = Height(node.Left);
            int rightHeight = Height(node.Right);
            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public void PrintTree()
        {
            PrintTree(root, "", true);
        }

        private void PrintTree(Node node, string indent, bool last)
        {
            if (node != null)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("R----");
                    indent += "     ";
                }
                else
                {
                    Console.Write("L----");
                    indent += "|    ";
                }
                Console.WriteLine($"{node.Key}({node.Priority})");

                PrintTree(node.Left, indent, false);
                PrintTree(node.Right, indent, true);
            }
        }

        public void LoadFromFile(string fileName)
        {
            try
            {
                Clear();
                foreach (var line in File.ReadAllLines(fileName))
                {
                    var parts = line.Split('(');
                    if (parts.Length != 2)
                        throw new FormatException("Line is not in the correct format 'key(priority)'");

                    var key = (TK)Convert.ChangeType(parts[0].Trim(), typeof(TK));
                    var priority = (TP)Convert.ChangeType(parts[1].Trim(')'), typeof(TP));

                    Insert(ref root, key, priority); 
                }
                Console.WriteLine("Values were successfully loaded.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading file: {e.Message}");
            }
        }

        public void SaveTreeToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var node in Iterator(root))
                    {
                        writer.WriteLine(node.PrintNode());
                    }
                }
                Console.WriteLine("Tree values were successfully saved.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error saving file: {e.Message}");
            }
        }

        private IEnumerable<Node> Iterator(Node node)
        {
            if (node != null)
            {
                foreach (var left in Iterator(node.Left))
                    yield return left;

                yield return node;

                foreach (var right in Iterator(node.Right))
                    yield return right;
            }
        }
    }
}
