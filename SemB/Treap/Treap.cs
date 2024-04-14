using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SemB.Treap
{
    class TreepPrvek<TK, TP> where TK : IComparable<TK> where TP : IComparable<TP>
    {
        public TK Hodnota { get; set; }
        public TP Pritorita { get; set; }

        public TreepPrvek<TK, TP> Levy;
        public TreepPrvek<TK, TP> Pravy;


        public TreepPrvek(TK hodnota, Func<TP> priorityGenerator)
        {
            Hodnota = hodnota;
            Pritorita = priorityGenerator();
        }



        public override string ToString()
        {
            return $"{Hodnota}({Pritorita})";
        }
    }

    class Treap<TK, TP> : ITreap<TK, TP> where TK : IComparable<TK> where TP : IComparable<TP>
    {
        private TreepPrvek<TK, TP> koren;
        private Func<TP> generatePriority;

        public Treap(Func<TP> priorityGenerator)
        {
            generatePriority = priorityGenerator;
            koren = null;
        }

        public int Pocet { get; private set; }


        public void Add(TK key)
        {
            Insert(ref koren, key);
        }

        private TreepPrvek<TK, TP> Insert(ref TreepPrvek<TK, TP> node, TK hodota)
        {
            if (node == null)
                return new TreepPrvek<TK, TP>(hodota, generatePriority);

            int cmp = hodota.CompareTo(node.Hodnota);
            if (cmp < 0)
            {
                node.Levy = Insert(ref node.Levy, hodota);
                if (node.Levy.Pritorita.CompareTo(node.Pritorita) < 0)
                    node = RotateRight(node);
            }
            else if (cmp > 0)
            {
                node.Pravy = Insert(ref node.Pravy, hodota);
                if (node.Pravy.Pritorita.CompareTo(node.Pritorita) < 0)
                    node = RotateLeft(node);
            }
            return node;
        }


        public void Clear()
        {
            koren = null;
            Pocet = 0;
        }

        public int Count()
        {
            return getCount(koren);
        }

        private int getCount(TreepPrvek<TK, TP> node)
        {
            if (node == null)
                return 0;
            else
                return 1 + getCount(node.Levy) + getCount(node.Pravy);
        }

        public void Remove(TK key)
        {
            koren = Delete(koren, key);
            Pocet--;
        }

        private TreepPrvek<TK, TP> Delete(TreepPrvek<TK, TP> node, TK key)
        {
            if (node == null) return null;

            int cmp = key.CompareTo(node.Hodnota);
            if (cmp < 0)
            {
                node.Levy = Delete(node.Levy, key);
            }
            else if (cmp > 0)
            {
                node.Pravy = Delete(node.Pravy, key);
            }
            else
            {
                if (node.Levy == null) return node.Pravy;
                else if (node.Pravy == null) return node.Levy;
                else if (node.Levy.Pritorita.CompareTo(node.Pravy.Pritorita) < 0)
                {
                    node = RotateLeft(node);
                    node.Levy = Delete(node.Levy, key);
                }
                else
                {
                    node = RotateRight(node);
                    node.Pravy = Delete(node.Pravy, key);
                }
            }
            return node;
        }

        public bool Find(TK key)
        {
            TreepPrvek<TK, TP> node = koren;
            while (node != null)
            {
                int cmp = key.CompareTo(node.Hodnota);
                if (cmp < 0) node = node.Levy;
                else if (cmp > 0) node = node.Pravy;
                else return true;
            }
            return false;
        }

        private TreepPrvek<TK, TP> RotateRight(TreepPrvek<TK, TP> node)
        {
            TreepPrvek<TK, TP> left = node.Levy;
            node.Levy = left.Pravy;
            left.Pravy = node;
            return left;
        }

        private TreepPrvek<TK, TP> RotateLeft(TreepPrvek<TK, TP> node)
        {
            TreepPrvek<TK, TP> right = node.Pravy;
            node.Pravy = right.Levy;
            right.Levy = node;
            return right;
        }

        public void PrintTree()
        {
            PrintTree(koren, "", true);
        }

        private void PrintTree(TreepPrvek<TK, TP> node, string indent, bool last)
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
                Console.WriteLine(node.ToString());

                PrintTree(node.Levy, indent, false);
                PrintTree(node.Pravy, indent, true);
            }
        }

        public int Height()
        {
            return Height(koren);
        }

        private int Height(TreepPrvek<TK, TP> node)
        {
            if (node == null)
                return 0;

            int leftHeight = Height(node.Levy);
            int rightHeight = Height(node.Pravy);

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public IEnumerable<TK> InOrderTraversal()
        {
            var list = new List<TK>();
            InOrderTraversal(koren, list);
            return list;
        }

        private void InOrderTraversal(TreepPrvek<TK, TP> node, List<TK> list)
        {
            if (node != null)
            {
                InOrderTraversal(node.Levy, list);
                list.Add(node.Hodnota);
                InOrderTraversal(node.Pravy, list);
            }
        }

    }
}
