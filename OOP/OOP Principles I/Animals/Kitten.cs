using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    class Kitten : Cat, ISound
    {
        public Kitten(int age, string name)
            : base(age, name, 'F')
        {

        }

        public override char Sex
        {
            get { return Sex; }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Mrrrrr!");
        }
    }
}
