using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    class School
    {
        private string name;
        private List<Class> classes = new List<Class>();

        public List<Class> Classes
        {
            get { return classes; }
            set { classes = value; }
        }


        public string Name
        {
            get { return name; }
        }

        public School(string name)
        {
            this.name = name;
        }
    }
}
