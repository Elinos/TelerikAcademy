//Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), 
//reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…). 
//Be sure to catch all possible exceptions and print user-friendly error messages.

using System;
using System.IO;
using System.Security;

class PrintFile
{
    static void Main()
    {
        try
        {
            Console.Write("Enter full path to file that you want to print: ");
            string pathToFile = Console.ReadLine();
            Console.WriteLine(File.ReadAllText(pathToFile));
        }
        catch (ArgumentNullException)
        {
            Console.Error.WriteLine("Path is null.");
        }

        catch (ArgumentException)
        {
            Console.Error.WriteLine("Path is a zero-length string, contains only white space, or contains one or more invalid characters.");
        }

        catch (PathTooLongException)
        {
            Console.Error.WriteLine("The specified path, file name, or both exceed the system-defined maximum length.");
        }

        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("The specified path is invalid.");
        }

        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("The file specified in path was not found.");
        }

        catch (IOException)
        {
            Console.Error.WriteLine("An I/O error occurred while opening the file.");
        }

        catch (UnauthorizedAccessException)
        {
            Console.Error.WriteLine("The caller does not have the required permission.");
        }

        catch (NotSupportedException)
        {
            Console.Error.WriteLine("This method doesn't support this functionality.");
        }

        catch (SecurityException)
        {
            Console.Error.WriteLine("The caller does not have the required permission.");
        }
    }
}

