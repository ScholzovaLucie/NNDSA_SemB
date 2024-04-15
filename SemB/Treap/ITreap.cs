using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemB.Treap
{
    internal interface ITreap<TK, TP> where TK : IComparable<TK> where TP : IComparable<TP> {

        void Add(TK key);
        bool Remove(TK key);
        object Find(TK key);
        void Clear();
        int Count();
        void PrintTree();
        int Height();

    }
}
