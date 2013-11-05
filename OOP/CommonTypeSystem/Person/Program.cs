using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
                                  {
                                      new Person("Pesho", 12),
                                      new Person("Peshka", 13),
                                      new Person("Ko-ne", null)
                                  };

            foreach (var person in people)
            {
                Console.WriteLine(person);
                Console.WriteLine();
            }
        }
    }
}
