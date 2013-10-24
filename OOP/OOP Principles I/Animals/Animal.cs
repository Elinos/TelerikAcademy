using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    abstract class Animal
    {
        private int age;
        private string name;
        private char sex;

        public Animal(int age, string name, char sex)
        {
            this.age = age;
            this.name = name;
            this.sex = sex;
        }

        public virtual char Sex
        {
            get { return sex; }
            set { sex = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public static double AverageAge(Animal[] animals)
        {
            return animals.Average(x => x.age);
        }
    }
}
