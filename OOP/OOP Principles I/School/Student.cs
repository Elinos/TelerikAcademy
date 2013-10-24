using System;
using System.Linq;

namespace School
{
    class Student : Person, IComment
    {
        private int classNumber;
        private string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }


        public int ClassNumber
        {
            get { return classNumber; }
            set { classNumber = value; }
        }

        public Student(string name, int classNumber)
            : base(name)
        {
            this.classNumber = classNumber;
        }
    }
}
