using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Person
    {
        private string name;
        private int? age;

        public int? Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Person(string name)
        {
            this.name = name;
        }

        public Person(string name, int? age)
            : this(name)
        {
            this.age = age;
        }

        public override string ToString()
        {
            return "Name: " + this.name + Environment.NewLine + "Age: " + (age == null ? "not specified" : this.age.ToString());
        }
    }
}
