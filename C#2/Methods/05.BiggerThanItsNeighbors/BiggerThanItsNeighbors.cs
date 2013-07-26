//5. Write a method that checks if the element at given 
//position in given array of integers is bigger than its 
//two neighbors (when such exist).
using System;

public class BiggerThanItsNeighbors
{
    static void Main()
    {
        int[] array = {1, 3, -2, 3, 31, 123};
        int position = 1;
        bool isBigger = CheckIfBigger(array, position);
        Console.WriteLine("The number on position {0} in this array is bigger than its neighbors - {1}", position, isBigger);
    }
  
    public static bool CheckIfBigger(int[] array, int position)
    {
        bool isBigger = true;
        if (array.Length == 1)
            isBigger = true;
        else if (position == 0 && array.Length != 1)
            isBigger = (array[position] > array[position + 1]) ? true : false;
        else if (position == array.Length - 1)
            isBigger = (array[position] > array[position - 1]) ? true : false;
        else
            isBigger = (array[position] > array[position + 1] && array[position] > array[position - 1]) ? true : false;
        return isBigger;
    }
}

