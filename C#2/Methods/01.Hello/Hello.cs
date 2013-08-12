//1. Write a method that asks the user for his name 
//and prints “Hello, <name>” (for example, “Hello, 
//Peter!”). Write a program to test this method.
using System;

public class Hello
{
    public static void Main()
    {
        Console.Write("Enter your name: ");
        SayHello(Console.ReadLine());
    }
  
    public static void SayHello(string name)
    {
        Console.WriteLine("Hello, {0}", name);
    }

    //To test this method use the menu => TEST => Run =>All Tests
}

