using System;
using System.Collections.Generic;
using System.Linq;

class SortByLength
{
    static void Main()
    {
        string[] array = new string[]
	{
	    "telerik",
	    "academy",
	    "is",
	    "sooo",
	    "nice",
	    "!!!"
	};
        foreach (string str in SortByLengthIe(array))
            Console.WriteLine(str);
    }

    static IEnumerable<string> SortByLengthIe(IEnumerable<string> elements)
    {
        // Use LINQ to sort the array received and return a copy.
        var sorted = from str in elements
                     orderby str.Length ascending
                     select str;
        return sorted;
    }
}