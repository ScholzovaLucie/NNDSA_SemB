using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemB.Generator
{
    public interface IPriorityGenerator<T>
    {
        public T Next();
    }
}
