namespace Computers
{
    using System;

    public abstract class Cpu
    {
        private static readonly Random RandomNumberGenerator = new Random();

        public Cpu(byte numberOfCores)
        {
            this.NumberOfCores = numberOfCores;
        }

        public byte NumberOfBits { get; set; }

        public byte NumberOfCores { get; set; }

        public string SquareNumber(int data)
        {
            int maxValue = this.CheckMaxValueOfCpu();
            return this.GetResultFromSquare(data, maxValue);
        }

        public int GenerateRandomNumber(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("minValue must be greater than maxValue");
            }

            int randomNumber = RandomNumberGenerator.Next(minValue, maxValue + 1);
            return randomNumber;
        }

        protected abstract int CheckMaxValueOfCpu();

        private string GetResultFromSquare(int data, int maxValue)
        {
            string result;

            if (data < 0)
            {
                result = "Number too low.";
            }
            else if (data > maxValue)
            {
                result = "Number too high.";
            }
            else
            {
                int square = data * data;
                result = string.Format("Square of {0} is {1}.", data, square);
            }

            return result;
        }
    }
}