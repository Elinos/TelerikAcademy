namespace Computers
{
    using System;
    using System.Linq;

    public abstract class Manufacturer
    {
        public abstract PC CreatePC();

        public abstract Laptop CreateLaptop();

        public abstract Server CreateServer();
    }
}