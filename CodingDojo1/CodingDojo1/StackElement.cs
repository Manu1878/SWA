using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo1
{
    class StackElement<T>
    {
        // Stores the value of the stack entry
        public T ValueOfElement
        {
            get;
            set;
        }

        // points the successor of this entry
        // the entry which was added before this one
        public StackElement<T> Successor
        {
            get;
            set;
        }
    }
}
