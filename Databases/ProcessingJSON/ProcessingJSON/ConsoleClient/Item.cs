using System;
using System.Linq;
using Newtonsoft.Json;

namespace ConsoleClient
{
    public class Item
    {
        public string Title { get; set; }
        [JsonProperty("link")]
        public string URL { get; set; }
        public string Category { get; set; }
    }
}
