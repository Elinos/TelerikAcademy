using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleClient
{
    class EntryPoint
    {
        private const string HtmlFilePath = @"..\..\..\index.html";
        private const string Url = "http://forums.academy.telerik.com/feed/qa.rss";
        private const string FilePath = @"..\..\..\qa.rss";

        static void Main()
        {
            //Download Rss
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(Url, FilePath);
            }

            //Parse to JSON
            XElement xmlFile = XElement.Load(FilePath);
            var jsonAsText = JsonConvert.SerializeXNode(xmlFile);

            //Print Titles on Console
            var jsonObj = JObject.Parse(jsonAsText);
            var items = jsonObj["rss"]["channel"]["item"];

            foreach (var item in items)
            {
                Console.WriteLine(item["title"]);
            }

            //Create POCOs
            var itemsToString = jsonObj["rss"]["channel"]["item"].ToString();
            List<Item> pocoItems = JsonConvert.DeserializeObject<List<Item>>(itemsToString);

            //Create HTML page
            CreateHtmlPage(pocoItems);
        }

        private static void CreateHtmlPage(IEnumerable<Item> items)
        {
            var htmlGenerator = new HtmlGenerator();
            string html = htmlGenerator.GenerateHtml(items);
            File.WriteAllText(HtmlFilePath, html);
            Console.WriteLine("\n" + new string('-', 50));
            Console.WriteLine("\nHtml page created in project folder!");
        }
    }
}


