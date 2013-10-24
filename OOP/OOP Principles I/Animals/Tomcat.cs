using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    class Tomcat : Cat, ISound
    {
        public Tomcat(int age, string name)
            : base(age, name, 'M')
        {

        }

        public override char Sex
        {
            get { return Sex; }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hsssss!");
        }
    }
}
