using SemB.Generator;
using SemB.Treap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemB.Experimenty
{
    internal class ZakladniExperiment
    {
        private Treap<string, int> treap;
        public ZakladniExperiment()
        {
            treap = new Treap<string, int>(new generator());
        }

        private class generator : IPriorityGenerator<int>
        {
            private int[] priorityArray = { 4, 7, 5, 10, 23, 65, 73 };
            int position = 0;

            public int Next()
            {
                int priority = priorityArray[position];

                if (priority +  1 < priorityArray.Length) position += 1;
                return priority;
            }
        }
       
        public void RunExperiment()
        {
            string[] hodnoty = { "G", "B", "H", "A", "E", "K", "I"};
            
            for (int i = 0; i < hodnoty.Length; i++)
            {
                treap.Add(hodnoty[i]);
            }
            treap.PrintTree();

            treap.Add("C");
            treap.PrintTree();


            treap.Add("D");
            treap.PrintTree();

            treap.Add("F");
            treap.PrintTree();

        }
    }
}
