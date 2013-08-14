//Write a program that reads an integer number and calculates and prints its square root. 
//If the number is invalid or negative, print "Invalid number". 
//In all cases finally print "Good bye". Use try-catch-finally.

using System;

class InvalidNumber
{
    static void Main()
    {
        try
        {
            Console.Write("Enter number: ");
            uint number = uint.Parse(Console.ReadLine());
            Console.WriteLine("The square root of {0} is {1}", number, Math.Sqrt((double)number));
        }
        catch (ArgumentNullException)
        {

            Console.Error.WriteLine("Invalid Number!");
        }

        catch (FormatException)
        {

            Console.Error.WriteLine("Invalid Number!");
        }
        catch (OverflowException)
        {

            Console.Error.WriteLine("Invalid Number!");
        }
        finally
        {
            Console.WriteLine("Goodbye!");
        }
    }
}

