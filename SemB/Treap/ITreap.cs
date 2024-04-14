using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemB.Treap
{
    internal interface ITreap<TK, TP> where TK : IComparable<TK> where TP : IComparable<TP> { 
        void Clear();
        int Count();


        void Add(TK key);
        void Remove(TK key);
        bool Find(TK key);

    }
}
