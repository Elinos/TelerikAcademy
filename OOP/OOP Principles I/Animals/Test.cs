using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    class Test
    {
        static void Main()
        {
            Kitten[] kittens =
            {
                new Kitten(3, "Zuzi"),
                new Kitten(1, "Muzi"),
                new Kitten(7, "Suzi"),
            };

            Console.WriteLine("Kittens average age: {0:f2}", Animal.AverageAge(kittens));

            Dog[] dogs =
            {
                new Dog(10, "Stamat", 'm'),
                new Dog(15, "Deizi", 'f'),
                new Dog(2, "Lora", 'f'),
            };

            Console.WriteLine("Dogs average age: {0:f2}", Animal.AverageAge(dogs));

            Cat[] cats =
            {
                new Cat(6, "Riko", 'm'),
                new Cat(25, "Nin", 'f'),
                new Cat(1, "B", 'f'),
            };

            Console.WriteLine("Cats average age: {0:f2}", Animal.AverageAge(cats));
        }
    }
}
