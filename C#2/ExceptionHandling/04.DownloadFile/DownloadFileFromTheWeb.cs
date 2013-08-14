//Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) 
//and stores it the current directory. Find in Google how to download files in C#. 
//Be sure to catch all exceptions and to free any used resources in the finally block.

using System;
using System.Net;

class DownloadFileFromTheWeb
{
    static void DownloadFile(string url, string nameOfFile)
    {
        WebClient webClient = new WebClient();
        try
        {
            webClient.DownloadFile(url, nameOfFile);
        }
        catch (ArgumentNullException)
        {
            Console.Error.WriteLine("The url or name of the file is null.");
        }
        catch (WebException)
        {
            Console.Error.WriteLine("Error while downloading the file.");
        }
        catch (NotSupportedException)
        {
            Console.Error.WriteLine("This method doesn't support this functionality.");
        }
        finally
        {
            webClient.Dispose();
        }

    }
    static void Main()
    {
        string url = "http://www.devbg.org/img/Logo-BASD.jpg";
        string nameOfFile = "../../image.jpg";
        Console.WriteLine ("Downloading file ({0})...", url);
        DownloadFile(url, nameOfFile);
    }
}

