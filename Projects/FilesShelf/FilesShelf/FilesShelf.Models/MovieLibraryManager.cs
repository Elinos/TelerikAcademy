using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FilesShelf.Models
{
    public class MovieLibraryManager : LibraryManager
    {
        private static IEnumerable<string> GetMoviePaths(string pathName)
        {
            var extensions = new List<string> { ".avi", ".mkv", ".mpeg", ".wmv", ".mp4", ".mpg" };
            return Directory.EnumerateFiles(pathName, "*.*", SearchOption.AllDirectories).Where(s => extensions.Contains(Path.GetExtension(s))).Select(Path.GetFileNameWithoutExtension).ToList();

        }

        static string GetMovieTitle(string moviePath)
        {
            var movieTitle = "";

            if (moviePath != null)
            {
                Regex regex = new Regex(@"(.*?)\.S?(\d{1,2})E?(\d{2})");
                Match movieNameClean = regex.Match(moviePath);

                movieTitle = movieNameClean.Groups[1].Value;

                StringBuilder sb = new StringBuilder(movieTitle);

                for (int i = 0; i < sb.Length; i++)
                {
                    var current = movieTitle[i];

                    if (char.IsPunctuation(current))
                    {
                        sb.Replace(current, ' ');
                    }
                }

                movieTitle = sb.ToString();
            }

            return movieTitle;
        }

        public void PlayMovie()
        {
            throw new System.NotImplementedException();
        }
    }
}
