using System;

namespace GenericMatrix
{
    class GenericMatrixUI
    {
        static void Main()
        {
            GenericMatrix<double> m1 = new GenericMatrix<double>(2, 2);
            GenericMatrix<double> m2 = new GenericMatrix<double>(2, 2);
            GenericMatrix<int> m3 = new GenericMatrix<int>(2, 3);
            GenericMatrix<int> m4 = new GenericMatrix<int>(3, 1);
            m2[1, 1] = 1;
            var sum = m1 + m2;
            var sub = m1 - m2;
            var prod = m3 * m4;
            bool isNonZero = m1 ? true : false;
            bool isZero = m1 ? false : true;
            Console.WriteLine("Added: \n" + sum);
            Console.WriteLine("Subtracted: \n" + sub);
            Console.WriteLine("Multiplied: \n" + prod);
            Console.WriteLine("Is matrix non-zero: " + isNonZero);
            Console.WriteLine("Is matrix zero: " + isZero);
        }
    }
}
