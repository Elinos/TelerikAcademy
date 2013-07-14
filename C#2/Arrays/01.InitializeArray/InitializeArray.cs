//1. Write a program that allocates array of 20 integers 
//and initializes each element by its index multiplied 
//by 5. Print the obtained array on the console.

using System;

class InitializeArray
{
    static void Main()
    {
        int[] multipliedArray = new int[20];
        for (int i = 0; i < multipliedArray.Length; i++)
        {
            multipliedArray[i] = i * 5; //init each element multiplied by 5
            Console.WriteLine("multipliedArray[{0}] = {1}", i, multipliedArray[i]); //print the element on the console
        }
    }
}

