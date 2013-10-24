using System;
using System.Linq;

namespace School
{
    public class SchoolTest
    {
        static void Main()
        {
            School justSchool = new School("JustSchool");

            Teacher ivanov = new Teacher("Ivanov");
            Teacher metodiev = new Teacher("Metodiev");

            Student milko = new Student("Milko", 15);
            Student vasil = new Student("Vasil", 2);

            Class bClass = new Class("BClass");

            Discipline math = new Discipline("Math", 5, 10);
            Discipline chemistry = new Discipline("Chemistry", 5, 12);

            justSchool.Classes.Add(bClass);

            bClass.Students.Add(milko);
            bClass.Students.Add(vasil);
            bClass.Teachers.Add(ivanov);
            bClass.Teachers.Add(metodiev);

            ivanov.Disciplines.Add(math);
            metodiev.Disciplines.Add(chemistry);

            bClass.Comment = "Pros";
        }
    }
}
