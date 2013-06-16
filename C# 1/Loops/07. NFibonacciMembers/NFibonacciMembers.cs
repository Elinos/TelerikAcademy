using System;
using System.Numerics;

class NFibonacciMembers
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        BigInteger firstMember = 0;
        BigInteger secondMember = 1;
        BigInteger thirdMember = 1;
        BigInteger sum = 0;

        for (int i = 1; i <= n; i++)
        {
            sum += firstMember;
            firstMember = secondMember;
            secondMember = thirdMember;
            thirdMember = firstMember + secondMember;
        }
        Console.WriteLine("Sum of first {0} Fibonacci members is: {1}", n, sum);
    }
}
