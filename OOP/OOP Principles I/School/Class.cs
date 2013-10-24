using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    class Class : IComment
    {
        private string textID;
        private string comment;
        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();

        public Class(string textID)
        {
            this.textID = textID;
        }

        public List<Teacher> Teachers
        {
            get { return teachers; }
            set { teachers = value; }
        }


        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }


        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }


        public string TextID
        {
            get { return textID; }
            set { textID = value; }
        }
    }
}
