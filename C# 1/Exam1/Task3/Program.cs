using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{
    static void Main()
    {
        string secretNumber = Console.ReadLine();
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        List<string> answers = new List<string>();

        for (int i = 1000; i <= 9999; i++)
        {
            if (i.ToString().Contains('0'))
            {
                continue;
            }
            else
            {
                answers.Add(i.ToString());
            }
        }
        List<string> correctAnswers = new List<string>();
        StringBuilder currentNumber = new StringBuilder();
        StringBuilder secretNumberToTest = new StringBuilder();
        for (int i = 0; i < answers.Count; i++)
        {
            int bulls = 0;
            int cows = 0;
            currentNumber.Append(answers[i]);
            secretNumberToTest.Append(secretNumber);
            for (int j = 0; j < 4; j++)
            {
                if (currentNumber[j] == secretNumberToTest[j])
                {
                    bulls++;
                    secretNumberToTest[j] = '*';
                    currentNumber[j] = '.';
                }
            } 
            for (int k = 0; k < 4; k++)
            {
                for (int s = 0; s < 4; s++)
                {
                    if (secretNumberToTest[k] == currentNumber[s])
                    {
                        cows++;
                        secretNumberToTest[k] = '*';
                        currentNumber[s] = '.';
                    }
                }
            }
            if ((bulls == b) && (cows == c))
            {
                correctAnswers.Add(answers[i]);
            }
            secretNumberToTest.Clear();
            currentNumber.Clear();
        }
        if ((b == 3 & c == 1) || correctAnswers.Count() == 0)
        {
            Console.WriteLine("No");
        }
        else
        {
            for (int i = 0; i < correctAnswers.Count(); i++)
            {
                Console.Write("{0} ", correctAnswers[i]);
            }
        }
    }
}