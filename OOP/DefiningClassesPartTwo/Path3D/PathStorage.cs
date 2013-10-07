using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Path3D
{
    public static class PathStorage
    {
        public static void SavePath(string file, List<Path> paths)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Path path in paths)
                sb.AppendLine(path.ToString());

            File.WriteAllText(file, sb.ToString());
        }

        public static void LoadPath(string file, List<Path> paths)
        {
            string rawText = (File.ReadAllText(file));
            string[] rawPaths = rawText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var p in rawPaths)
            {
                string[] path = p.Split(new string[] {"; "}, StringSplitOptions.RemoveEmptyEntries);
                Path pathToAdd = new Path();
                foreach (var point in path)
                {
                    int[] coords = Regex.Split(point, @"\D+").Where(c => c != "").Select(x => int.Parse(x)).ToArray();
                    pathToAdd.AddPoint(new Point3D(coords[0], coords[1], coords[2]));
                }
                paths.Add(pathToAdd);
            }
        }
    }
}
