using System;
using System.Text;

class SumOfSomeSubset
{
    static void Main()
    {
        int lookingSum = 0; //the sum we are looking for
        int[] myArray = new int[5]; //array with numbers 
        int length = myArray.Length; //array length
        int totalSum; //
        StringBuilder elementValue = new StringBuilder();
        int isOne;
        int bitLength = 0;
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Enter a number({0}): ", i + 1);
            myArray[i] = Convert.ToInt32(Console.ReadLine());
        }

        for (int subset = 1; subset < 32; subset++)
        {
            //zero the variables
            elementValue.Clear();
            totalSum = 0;
            //if the last bits are 0 we don't have to check them
            bitLength = Convert.ToString(subset, 2).Length;

            for (int element = 0; element < bitLength; element++)
            {
                //if the bit is 1 we check the corresponding element in the array
                isOne = (subset & (1 << element));

                if (isOne != 0)
                {
                    totalSum += myArray[element];
                    elementValue.Append(" ");
                    elementValue.Append(myArray[element]);
                }
            }
            if (totalSum == lookingSum)
            {
                Console.WriteLine(new string('-', 30));
                Console.WriteLine("The subset with sum: {0}", lookingSum);
                Console.WriteLine("Value of the array: {0}", elementValue);
                Console.WriteLine(new string('-', 30));
            }
        }
    }
}