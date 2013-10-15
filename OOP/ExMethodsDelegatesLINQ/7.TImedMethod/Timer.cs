using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Timer
{
    public delegate void Timed();
    
    public static void Execute(int seconds,Timed method)
    {
        var lastExecution = DateTime.Now;
        method();
        while (true)
        {
            if ((DateTime.Now - lastExecution).TotalSeconds >= seconds)
            {
                method();
                lastExecution = DateTime.Now;
            }
        }
    }
}

