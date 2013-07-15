//15. Write a program that finds all prime numbers 
//in the range [1...10 000 000]. Use the sieve of 
//Eratosthenes algorithm (find it in Wikipedia).
using System;
using System.Collections.Generic;
using System.Linq;

class PrimeNumbers
{
    static int[] GetPrimes(int maxValue)
    {
        //Create a boolean array with each bool indicating if it is not prime
        bool[] primes = new bool[maxValue];

        for (int i = 2; i < primes.Length; )
        {
            //short circuit our sieve if i squared is greater than the length
            if (i * i > primes.Length)
                break;
            //do the sieving
            for (int j = i * i; j < primes.Length; j += i)
                primes[j] = true;

            //look for our next value to sieve on
            for (i++; i < primes.Length; i++)
                if (!primes[i])
                    break;
        }

        //Build our results from array
        List<int> results = new List<int>();
        for (int i = 2; i < primes.Length; i++)
        {
            if (!primes[i])
                results.Add(i);
        }

        return results.ToArray();
    }

    static void Main()
    {
        Console.WriteLine("There are {0} prime numbers in the range [1...10 000 000]", GetPrimes(10000000).Count());
        //Uncomment if you want to print them
        //Console.WriteLine(String.Join("\n", GetPrimes(10000000)));  
    }
}