namespace Computers
{
    using System;
    using System.Linq;

    public class Cpu128Bit : Cpu
    {
        private const int MaxNumberThatCanBeCalculated = 2000;

        public Cpu128Bit(byte numberOfCores)
            : base(numberOfCores)
        {
            this.NumberOfBits = 128;
        }

        protected override int CheckMaxValueOfCpu()
        {
            return MaxNumberThatCanBeCalculated;
        }
    }
}