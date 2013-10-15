using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3_5.Students
{
    class OrderAlphabetically
    {
        static void Main()
        {
            Students[] students = new Students[3];
            students[0] = new Students("Boyko", "Borisov", 20);
            students[1] = new Students("Sashka", "Vaseva", 60);
            students[2] = new Students();

            Console.WriteLine("Task 3");
            foreach (var student in FirstNameBeforeLast(students))
                Console.WriteLine(student);

            Console.WriteLine();
            Console.WriteLine("Task 4");

            foreach (var student in FindStudentFrom18To24(students))
                Console.WriteLine(student);

            Console.WriteLine();
            Console.WriteLine("Task 5");
            
            Students[] studentsByLambda = students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName).ToArray();
            Students[] studentsByLINQ = OrderStudentsLINQ(students);
            foreach (var student in studentsByLINQ)
                Console.WriteLine(student);
        }

        // Task 3
        public static Students[] FirstNameBeforeLast(Students[] listOfStudents)
        {
            return listOfStudents.Where(x => x.FirstName.CompareTo(x.LastName) < 0).ToArray();
        }

        // Task 4
        public static Students[] FindStudentFrom18To24(Students[] listOfStudents)
        {
            return listOfStudents.Where(x => x.Age >= 18 && x.Age <= 24).ToArray(); 
        }

        //Task 5
        public static Students[] OrderStudentsLINQ(Students[] listOfStudents)
        {
            var ordered = from student in listOfStudents
                          orderby student.FirstName descending, student.LastName descending
                          select student;
            return ordered.ToArray();
        }
        
    }
}
