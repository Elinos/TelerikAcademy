/***************************************************************
 * 
 * 12. Write a program that parses an URL address given 
 * in the format:
 * 
 * [protocol]://[server]/[resource]
 * 
 * and extracts from it the [protocol], [server] 
 * and [resource] elements. For example from the 
 * URL http://www.devbg.org/forum/index.php 
 * the following information should be extracted:
 * [protocol] = "http"
 * [server] = "www.devbg.org"
 * [resource] = "/forum/index.php"
 * 
 ***************************************************************/
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class ParseURL
{
    static void Main()
    {
        Match match = Regex.Match(File.ReadAllText("../../input.txt"), @"(?<protocol>.*?)://(?<server>[^/]*)(?<resource>.*)");
        Console.WriteLine("[Protocol] = {0}\n[Server] = {1}\n[Resource] = {2}", match.Groups["protocol"], match.Groups["server"], match.Groups["resource"]);
    }
}
