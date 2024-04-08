using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemB.Treap
{
    internal class TreepPrvek<TKey> where TKey : IComparable
    {
        public TreepPrvek(TKey hodnota)
        {
            Hodnota = hodnota;
            Pritorita = new Random().Next();
        }

        public TKey Hodnota { get; set; }
        public int Pritorita { get; set; }

        public TreepPrvek<TKey> Levy;
        public TreepPrvek<TKey> Pravy;
    }
}
