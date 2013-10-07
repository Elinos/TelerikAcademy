using System;

namespace GenericList
{
    class GenericListUI
    {
        static void Main()
        {
            // Task 5, 6
            GenericList<int> gl = new GenericList<int>();
            gl.Add(4);
            gl.Add(3);
            gl.Add(2);
            gl.Add(2);
            Console.WriteLine(gl);
            gl.Add(5);
            Console.WriteLine(gl);

            Console.WriteLine(gl.FindIndex(2));

            gl.RemoveAt(1);
            Console.WriteLine(gl);

            gl.InsertAt(15, 2);
            Console.WriteLine(gl);

            // Task 7
            Console.WriteLine(gl.Min());
            Console.WriteLine(gl.Max());
        }
    }
}
