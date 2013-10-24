using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanBeings
{
    class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.grade = grade;
        }

        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

    }
}
