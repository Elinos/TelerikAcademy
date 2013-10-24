using System;
using System.Linq;

namespace School
{
    class Discipline : IComment
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;
        private string comment;

        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercies = numberOfExercises;
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }


        public int NumberOfExercies
        {
            get { return numberOfExercises; }
            set { numberOfExercises = value; }
        }


        public int NumberOfLectures
        {
            get { return numberOfLectures; }
            set { numberOfLectures = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
