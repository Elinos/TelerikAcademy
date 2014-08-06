namespace Computers
{
    using System;
    using System.Linq;

    public class Cpu32Bit : Cpu
    {
        private const int MaxNumberThatCanBeCalculated = 500;

        public Cpu32Bit(byte numberOfCores)
            : base(numberOfCores)
        {
            this.NumberOfBits = 32;
        }

        protected override int CheckMaxValueOfCpu()
        {
            return MaxNumberThatCanBeCalculated;
        }
    }
}