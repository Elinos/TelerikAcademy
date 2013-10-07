using System;
using System.Collections.Generic;

namespace Path3D
{
    class Path3DUI
    {
        static void Main()
        {
            // Task 1
            Point3D pointOne = new Point3D(1, 1, 3);
            Point3D pointTwo = new Point3D(3, 4, 6);
            Console.WriteLine(pointOne);
            Console.WriteLine(pointTwo);

            // Task 2
            Point3D pointThree = Point3D.PointO;
            Console.WriteLine(pointThree);

            // Task 3
            Console.WriteLine(Distance3D.GetDistance(pointOne, pointTwo));


            // Task 4.1
            Path pathOne = new Path(pointOne, pointTwo, pointThree);
            Path pathTwo = new Path(pointThree, pointTwo, pointOne);
            List<Path> paths = new List<Path>();
            paths.Add(pathOne);
            paths.Add(pathTwo);

            // Task 4.2
            PathStorage.SavePath("../../Paths.txt", paths);
            paths.Clear();
            PathStorage.LoadPath("../../Paths.txt", paths);
        }
    }
}
