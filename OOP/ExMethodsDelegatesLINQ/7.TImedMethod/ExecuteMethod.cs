using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ExecuteMethod
{
    public static void Method()
    {
        Console.WriteLine("I was called by a delegate at {0}", DateTime.Now.ToLongTimeString());
    }
    static void Main()
    {
        Timer.Execute(3, Method);
    }
}

