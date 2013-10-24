using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanBeings
{
    class Test
    {
        static void Main()
        {

            List<Student> students = new List<Student>();
            students.Add(new Student("Ivan", "Ivanov", 4));
            students.Add(new Student("Gosho", "Pochivka", 6));
            students.Add(new Student("Tosho", "Trifonov", 5));
            students.Add(new Student("Pesho", "Ivanov", 1));
            students.Add(new Student("Sasho", "Petrov", 2));
            students.Add(new Student("Mynio", "Stoyanov", 5));
            students.Add(new Student("Gydio", "Nikolov", 3));
            students.Add(new Student("Sashka", "Stoicheva", 2));
            students.Add(new Student("Penka", "Vasileva", 4));
            students.Add(new Student("Ginka", "Manolova", 6));

            var orderedStudents = students.OrderBy(x => x.Grade);
            foreach (var student in orderedStudents)
            {
                Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, student.Grade);
            }

            Console.WriteLine();

            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Stefan", "Samuilov", 1000, 8));
            workers.Add(new Worker("Miroslav", "Naidenov", 200, 4));
            workers.Add(new Worker("Maruska", "Dragicheva", 1500, 24));
            workers.Add(new Worker("Svetlio", "Ivanov", 100, 1));
            workers.Add(new Worker("Misho", "Sotirov", 3500, 3));
            workers.Add(new Worker("Slavi", "Trifonov", 0, 8));
            workers.Add(new Worker("Nadia", "Lukanova", 1234, 3));
            workers.Add(new Worker("Anton", "Valeriev", 100000, 2));
            workers.Add(new Worker("Stanislava", "Aranudova", 1000, 12));
            workers.Add(new Worker("Monika", "Georgieva", 500, 6));

            var orderedWorkers = from worker in workers
                                 orderby worker.MoneyPerHour() descending
                                 select worker;

            foreach (var worker in orderedWorkers)
            {
                Console.WriteLine("{0} {1} {2}", worker.FirstName, worker.LastName, worker.MoneyPerHour());
            }

            Console.WriteLine();

            List<Human> humans = new List<Human>();
            humans.AddRange(students);
            humans.AddRange(workers);
            var sortedList = humans.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            foreach (var human in sortedList)
            {
                Console.WriteLine("{0} {1}", human.FirstName, human.LastName);
            }
        }
    }
}
