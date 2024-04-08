using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SemB.Treap
{
    internal class Treap<TKey>: ITreap<TKey> where TKey : IComparable
    {
        private TreepPrvek<TKey> koren;

        public Treap()
        {
            koren = null;
        }

        public int Pocet { get; private set; }


        public void Add(TKey key)
        {
            Insert(ref koren, key);
        }

        private TreepPrvek<TKey> Insert(ref TreepPrvek<TKey> node, TKey key)
        {
            if (node == null)
                return new TreepPrvek<TKey>(key);

            int cmp = key.CompareTo(node.Hodnota);
            if (cmp < 0)
            {
                node.Levy = Insert(ref node.Levy, key);
                if (node.Levy.Pritorita > node.Pritorita)
                    node = RotateRight(node);
            }
            else if (cmp > 0)
            {
                node.Pravy = Insert(ref node.Pravy, key);
                if (node.Pravy.Pritorita > node.Pritorita)
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

        private int getCount(TreepPrvek<TKey> node)
        {
            if (node == null)
                return 0;
            else
                return 1 + getCount(node.Levy) + getCount(node.Pravy);
        }

        public void Remove(TKey key)
        {
            koren = Delete(koren, key);
            Pocet--;
        }

        private TreepPrvek<TKey> Delete(TreepPrvek<TKey> node, TKey key)
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
                else if (node.Levy.Pritorita < node.Pravy.Pritorita)
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

        public bool Find( TKey key)
        {
            TreepPrvek<TKey> node = koren;
            while (node != null)
            {
                int cmp = key.CompareTo(node.Hodnota);
                if (cmp < 0) node = node.Levy;
                else if (cmp > 0) node = node.Pravy;
                else return true;
            }
            return false;
        }

        private TreepPrvek<TKey> RotateRight(TreepPrvek<TKey> node)
        {
            var left = node.Levy;
            node.Levy = left.Pravy;
            left.Pravy = node;
            return left;
        }

        private TreepPrvek<TKey> RotateLeft(TreepPrvek<TKey> node)
        {
            var right = node.Pravy;
            node.Pravy = right.Levy;
            right.Levy = node;
            return right;
        }

        public void PrintTree()
        {
            PrintTree(koren, "", true);
        }

        private void PrintTree(TreepPrvek<TKey> node, string indent, bool last)
        {
            // Kontrola, zda aktuální uzel není null
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
                // Výpis aktuálního uzlu
                Console.WriteLine($"{node.Hodnota}({node.Pritorita})");

                // Rekurzivní výpis levého a pravého potomka
                PrintTree(node.Levy, indent, false);
                PrintTree(node.Pravy, indent, true);
            }
        }

        public int Height()
        {
            return Height(koren);
        }

        private int Height(TreepPrvek<TKey> node)
        {
            if (node == null)
                return 0;

            int leftHeight = Height(node.Levy);
            int rightHeight = Height(node.Pravy);

            return 1 + Math.Max(leftHeight, rightHeight);
        }

    }
}
