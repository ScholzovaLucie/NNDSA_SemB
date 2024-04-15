using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemB.Generator
{
    public class IntPriorityGenerator: IPriorityGenerator<int>
    {
        Random rng = new Random();
        public IntPriorityGenerator()
        {

        }

        public int Next()
        {
            return rng.Next();
        }
    }
}
