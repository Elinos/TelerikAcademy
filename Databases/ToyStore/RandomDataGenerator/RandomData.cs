namespace RandomDataGenerator
{
    using System;

    public class RandomData
    {
        //private const string allAlphaNumeric = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        //private const string smallLetters = "abcdefghijklmnopqrstuvwxyz";
        //private const string bigLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        //private const string numerics = "1234567890";

        private const string allLeters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static RandomData instance;

        private readonly Random random;

        private RandomData()
        {
            this.random = new Random();
        }

        public static RandomData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RandomData();
                }

                return instance;
            }
        }

        public string GetStringExact(int length, string charsToUse = allLeters)
        {
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = charsToUse[this.random.Next(0, charsToUse.Length)];
            }

            return new string(result);
        }

        public string GetString(int min, int max, string charsToUse = allLeters)
        {
            return this.GetStringExact(this.random.Next(min, max + 1), charsToUse);
        }

        public int GetInt(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public double GetDouble(double min, double max)
        {
            return this.random.NextDouble() * (max - min) + min;
        }

        public bool GetChance(int percent)
        {
            return this.random.Next(0, 101) <= percent;
        }
    }
}