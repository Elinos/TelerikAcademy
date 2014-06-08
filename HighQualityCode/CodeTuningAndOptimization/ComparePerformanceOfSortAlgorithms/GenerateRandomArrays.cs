namespace _04.ComparePerformanceOfSortAlgorithms
{
    using System;
    using System.Linq;

    public class GenerateRandomArrays
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789~`!@#$%^&*()-_=+[{]}\\|;:'\",<.>/?";
        private static Random randomNumber = new Random();

        public static int[] GetRandomIntArray(int length)
        {
            int[] value = new int[length];

            for (int i = 0; i < value.Length; i++)
            {
                value[i] = randomNumber.Next(int.MinValue, int.MaxValue);
            }

            return value;
        }

        public static double[] GetRandomDoubleArray(int length)
        {
            double[] value = new double[length];

            for (int i = 0; i < value.Length; i++)
            {
                int sign = randomNumber.Next(0, 2);
                if (sign == 0)
                {
                    value[i] = randomNumber.NextDouble() * double.MaxValue;
                }
                else
                {
                    value[i] = randomNumber.NextDouble() * double.MinValue;
                }
            }

            return value;
        }

        public static string[] GetRandomStringArray(int length, int stringMaxSize)
        {
            string[] value = new string[length];

            for (int i = 0; i < value.Length; i++)
            {
                value[i] = GetRandomString(randomNumber.Next(1, stringMaxSize + 1));
            }

            return value;
        }

        public static string GetRandomString(int size)
        {
            char[] buffer = new char[size];
            int length = Chars.Length;

            for (int i = 0; i < size; i++)
            {
                buffer[i] = Chars[randomNumber.Next(length)];
            }

            return new string(buffer);
        }
    }
}