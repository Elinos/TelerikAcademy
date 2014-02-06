using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists(@"..\..\input.txt"))
                Console.SetIn(new StreamReader(@"..\..\input.txt"));



            BigInteger mollyFlowers = 0;
            BigInteger dollyFlowers = 0;
            string firstToReachEmptyCell = String.Empty;




            string input = Console.ReadLine().Trim();
            BigInteger[] field = input.Split().Select(x => BigInteger.Parse(x)).ToArray();
            int n = field.Length;
            bool[] visited = new bool[n];
            int mollyPosition = 0;
            int dollyPosition = n - 1;

            BigInteger mollyStep = field[mollyPosition];
            BigInteger dollyStep = field[dollyPosition];

            int mollyNextPosition = (int)(Modulo(mollyPosition + Modulo(mollyStep, n), n));
            int dollyNextPosition = (int)(Modulo(dollyPosition - Modulo(dollyStep, n), n));


            mollyFlowers += field[mollyPosition];
            dollyFlowers += field[dollyPosition];
            if (field[mollyPosition] == 0)
            {
                visited[mollyPosition] = true;
            }
            if (field[dollyPosition] == 0)
            {
                visited[dollyPosition] = true;
            }

            field[mollyPosition] = 0;
            field[dollyPosition] = 0;

            while (!visited[mollyNextPosition] && !visited[dollyNextPosition])
            {

                mollyPosition = (int)(Modulo(mollyPosition + Modulo(mollyStep, n), n));
                dollyPosition = (int)(Modulo(dollyPosition - Modulo(dollyStep, n), n));
                if (visited[dollyNextPosition] || visited[mollyNextPosition])
                {
                    break;
                }


                if (mollyPosition == dollyPosition)
                {
                    mollyStep = field[mollyPosition];
                    dollyStep = field[dollyPosition];
                    if (field[mollyPosition] == 0)
                    {
                        visited[mollyPosition] = true;
                    }
                    if (field[dollyPosition] == 0)
                    {
                        visited[dollyPosition] = true;
                    }

                    mollyFlowers += field[mollyPosition] / 2;
                    dollyFlowers += field[dollyPosition] / 2;
                    if (field[mollyPosition].IsEven)
                    {
                        field[mollyPosition] = 0;
                        visited[mollyPosition] = true;
                    }
                    else
                    {
                        field[mollyPosition] = 1;
                    }
                }
                else
                {
                    mollyStep = field[mollyPosition];
                    dollyStep = field[dollyPosition];
                    if (field[mollyPosition] == 0)
                    {
                        visited[mollyPosition] = true;
                    }
                    if (field[dollyPosition] == 0)
                    {
                        visited[dollyPosition] = true;
                    }

                    mollyFlowers += field[mollyPosition];
                    field[mollyPosition] = 0;
                    visited[mollyPosition] = true;

                    dollyFlowers += field[dollyPosition];
                    field[dollyPosition] = 0;
                    visited[dollyPosition] = true;

                }

                mollyNextPosition = (int)(Modulo(mollyPosition + Modulo(mollyStep, n), n));
                dollyNextPosition = (int)(Modulo(dollyPosition - Modulo(dollyStep, n), n));

            }


            if (visited[dollyNextPosition] && visited[mollyNextPosition])
            {
                firstToReachEmptyCell = "Draw";
            }
            else if (visited[mollyNextPosition])
            {
                firstToReachEmptyCell = "Dolly";
                dollyFlowers += field[dollyPosition];
            }
            else
            {
                firstToReachEmptyCell = "Molly";
                mollyFlowers += field[mollyPosition];
            }
            Console.WriteLine(firstToReachEmptyCell);
            Console.WriteLine("{0} {1}", mollyFlowers, dollyFlowers);

        }
        static BigInteger Modulo(BigInteger x, int m)
        {
            return (x % m + m) % m;
        }
    }

}
