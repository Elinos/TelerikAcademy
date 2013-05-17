using System;

class NullIntAndDouble
{
    static void Main()
    {
        int? nullableInt = null;
        double? nullableDouble = null;

        Console.WriteLine("This is the value of nullableInt: {0}\nand this is the value of nullableDouble: {1}\nI see what you did there! :)\n", nullableInt, nullableDouble);
        
        Console.WriteLine("nullableInt + 5 is {0}", nullableInt + 5);
        Console.WriteLine("nullableDouble + 7 is {0}", nullableDouble + 7);
        
        Console.WriteLine("Still nothing when we add nullableInt and the null literal: {0}", nullableInt + null);
    }
}

