using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestWithInt();
            //TestWithString();
            //TestWithObject();
            Console.ReadLine();
        }

        static void TestWithInt()
        {
            Stack<int> test = new Stack<int>();

            test.Push(2);
            test.Push(3);
            Console.WriteLine("read: {0}", test.Peek());
            test.Push(4);
            Console.WriteLine("read: {0}", test.Peek());
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("read: {0}", test.Peek());
            Console.WriteLine("{0} removed", test.Pop());
        }

        static void TestWithString()
        {
            Stack<string> test = new Stack<string>();

            test.Push("E1");
            test.Push("E2");
            Console.WriteLine("read: {0}", test.Peek());
            test.Push("E3");
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("read: {0}", test.Peek());
            Console.WriteLine("{0} removed", test.Pop());
        }

        static void TestWithObject()
        {
            Stack<TestObject> test = new Stack<TestObject>();

            test.Push(new TestObject(27, "Manuel"));
            Console.WriteLine("read {0}", test.Peek());
            test.Push(new TestObject(25, "Johanna"));
            Console.WriteLine("read {0}", test.Peek());
            test.Push(new TestObject(30, "Bernhard"));
            Console.WriteLine("read {0}", test.Peek());
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("read {0}", test.Peek());
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("read {0}", test.Peek());
            Console.WriteLine("{0} removed", test.Pop());
            Console.WriteLine("read {0}", test.Peek());
        }
    }
}
