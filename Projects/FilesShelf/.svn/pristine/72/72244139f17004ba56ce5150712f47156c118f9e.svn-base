using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;

namespace FilesShelf.Models
{
    public class BookLibraryManager : LibraryManager
    {
        public void ReadBook()
        {
            throw new System.NotImplementedException();
        }

        //This method parses the pdf and returns a string with text content
        public static string ParseUsingPdfBox(string filename)
        {
            PDDocument doc;

            try
            {
                doc = PDDocument.load(filename);
            }
            catch
            {
                return null;
            }

            var sb = new StringBuilder();
            var stripper = new PDFTextStripper();
            var lastPage = stripper.getEndPage();
            var lastPageMinus10 = lastPage - 10;

            stripper.setStartPage(1);
            stripper.setEndPage(10);
            string temp = stripper.getText(doc);
            sb.Append(temp);

            stripper.setStartPage(lastPageMinus10);
            stripper.setEndPage(lastPage);
            temp = stripper.getText(doc);

            sb.Append(temp);
            doc.close();
            return sb.ToString();
        }

        //This method includes gets all book paths from a directory
        public static IEnumerable<string> GetBookPath(string pathName)
        {
            return Directory.EnumerateFiles(pathName, "*.pdf", SearchOption.AllDirectories).Select(Path.GetFullPath).ToList();
        }


        //this method removes digits (if present) from the matchcollection
        public static string RemoveDigitsFromMatchCollection(MatchCollection matches)
        {
            if (matches.Count == 0)
            {
                return null;
            }

            string correctMatch = "";

            for (int i = 0; i < matches.Count; i++)
            {
                var currentMatch = matches[i].ToString().ToCharArray();
                bool isDigitPresent = currentMatch.Any(char.IsDigit);

                if (isDigitPresent)
                {
                    for (int j = 0; j < currentMatch.Length; j++)
                    {
                        var current = currentMatch[j];

                        if (char.IsDigit(current))
                        {
                            current = ' ';
                            currentMatch[j] = current;
                        }
                    }
                }
            }

            correctMatch = matches[0].Value;
            return correctMatch;
        }

        //This method extracts the ISBN from a given string
        public static string GetIsbn(string text)
        {

            var result = new System.Text.StringBuilder();

            Regex regex = new Regex(@"ISBN(-1(?:(0)|3))?");

            if (text != null)
            {
                var isbnText = regex.Matches(text);

                var correctMatch = RemoveDigitsFromMatchCollection(isbnText);

                if (correctMatch != null)
                {
                    var charCount = correctMatch.Length;

                    var isbnIndexRaw = text.IndexOf(correctMatch, System.StringComparison.Ordinal);

                    var isbnIndexClean = isbnIndexRaw + charCount;

                    var isbnNumRaw = text.Substring(isbnIndexClean, 100).ToCharArray();

                    var breakPoint = 0;

                    for (int i = 0; i < isbnNumRaw.Length; i++)
                    {
                        char current = isbnNumRaw[i];

                        if (current == '\n' || current == '\r')
                        {
                            breakPoint = i;
                            break;
                        }
                    }

                    var isbnNumCleaned = text.Substring(isbnIndexClean, breakPoint);

                    foreach (var c in isbnNumCleaned)
                    {
                        if (char.IsDigit(c))
                        {
                            result.Append(c);
                        }
                    }


                    if (result.ToString().StartsWith("13") && result.Length > 10)
                    {
                        result = result.Remove(0, 2);
                    }

                    if (result.ToString().StartsWith("9") && result.Length > 13)
                    {
                        result = result.Remove(13, result.Length - 13);
                    }

                    if (!(result.ToString().StartsWith("9")) && result.Length > 10)
                    {
                        result = result.Remove(10, result.Length - 10);
                    }

                }

                else
                {
                    return null;
                }

            }

            return result.ToString();
        }
    }
}
