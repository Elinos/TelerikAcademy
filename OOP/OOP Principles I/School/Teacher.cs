using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    class Teacher : Person, IComment
    {
        private string comment;
        private List<Discipline> disciplines = new List<Discipline>();

        public List<Discipline> Disciplines
        {
            get { return disciplines; }
            set { disciplines = value; }
        }
        

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        public Teacher(string name)
            : base(name)
        {
        }
    }
}
