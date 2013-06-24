using System;


class Program
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int mPoints = 0;
        int vPoints = 0;
        for (int i = 0; i < N; i++)
        {
            string roundNumber = Console.ReadLine();
            roundNumber = roundNumber.TrimStart('-');
            roundNumber = roundNumber.TrimStart('0');
            for (int j = 0; j < roundNumber.Length; j++)
            {
                if (j < (roundNumber.Length / 2))
                {
                    mPoints += (roundNumber[j] - '0');
                }
                else
                {
                    vPoints += (roundNumber[j] - '0');
                }
            }
            if ((roundNumber.Length % 2) != 0)
            {
                mPoints += roundNumber[(roundNumber.Length / 2)] - '0';
            }
        }
        if (mPoints > vPoints)
        {
            Console.WriteLine("M {0}", mPoints - vPoints);
        }
        else if (vPoints > mPoints)
        {
            Console.WriteLine("V {0}", vPoints - mPoints);
        }
        else
        {
            Console.WriteLine("No {0}", mPoints + vPoints);
        }
    }
}