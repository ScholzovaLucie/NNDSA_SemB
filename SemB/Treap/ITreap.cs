using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemB.Treap
{
    internal interface ITreap<TKey>
    {
        void Clear();
        int Count();


        void Add(TKey key);
        void Remove(TKey key);
        bool Find(TKey key);

    }
}
