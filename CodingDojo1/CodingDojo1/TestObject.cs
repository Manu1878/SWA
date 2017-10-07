using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo1
{
    class TestObject
    {
        // attributes
        public int Age { get; set; }
        public string Name { get; set; }

        // constructor
        public TestObject(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        // Method
        public override string ToString()
        {
            return String.Format("{0} : {1}", Age, Name);
        }

    }
}
