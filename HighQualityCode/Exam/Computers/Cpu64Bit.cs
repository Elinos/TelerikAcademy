namespace Computers
{
    using System;
    using System.Linq;

    public class Cpu64Bit : Cpu
    {
        private const int MaxNumberThatCanBeCalculated = 1000;

        public Cpu64Bit(byte numberOfCores)
            : base(numberOfCores)
        {
            this.NumberOfBits = 64;
        }

        protected override int CheckMaxValueOfCpu()
        {
            return MaxNumberThatCanBeCalculated;
        }
    }
}