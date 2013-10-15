using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_5.Students
{
    class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Students()
            : this("Pesho", "Ivanov", 18)
        {
        }

        public Students(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public override string ToString()
        {
            return "Name: " + this.FirstName + " " + this.LastName + "\t" + "Age: " + this.Age;
        }

    }
}
