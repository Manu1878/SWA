using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo1
{
    class Stack<T>
    {

        private StackElement<T> currentElement;

        // Add's new element to the stack
        public void Push(T item)
        {
            if(currentElement == null)
            {
                currentElement = new StackElement<T>() { ValueOfElement = item, Successor = null };
            }
            else
            {
                StackElement<T> temp = new StackElement<T>() { ValueOfElement = item, Successor = currentElement };
                currentElement = temp;
            }
        }

        // Removes the last entry from the stack
        // If stack is empty pop will return a default value
        public T Pop()
        {
            if(currentElement != null)
            {
                T temp = currentElement.ValueOfElement;
                currentElement = currentElement.Successor;
                return temp;
            }
            else
            {
                // Throw exception because stack is empty
                throw new NullReferenceException();
            }
        }

        // Returns the value of the last entry (which is on top of the stack)
        // If the stack is empty peek will return a default value
        public T Peek()
        {
            if(currentElement != null)
            {
                return currentElement.ValueOfElement;
            }
            else
            {
                return default(T);
            }
        }
    }
}
