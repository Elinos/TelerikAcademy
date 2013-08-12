//6.Write a method that returns the index of the first element 
//in array that is bigger than its neighbors, or -1,
//if there’s no such element. Use the method from the previous exercise.
using System;

class BiggerThanItsNeighbors2
{
    static void Main()
    {
        int[] array = { 1, 3, 5, 9, 31, 31 };
        int index = FindFirstBiggestNumber(array);
        if (index != -1)
            Console.WriteLine("The index of the first biggest number than its neighbors in this array is {0}", index);            
        else
            Console.WriteLine("There is no such number in this array!");
    }

    private static int FindFirstBiggestNumber(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
            if (BiggerThanItsNeighbors.CheckIfBigger(array, i)) //we use the method from last solution
                return i;
        return -1;		 
	}
}

