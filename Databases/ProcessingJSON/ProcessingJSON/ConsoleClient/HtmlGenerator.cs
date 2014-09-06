using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleClient
{
    class HtmlGenerator
    {
        private const string ItemTemplate = "<li>[{1}] <a href=\"{0}\">{2}</a></li>";
        internal string GenerateHtml(IEnumerable<Item> items)
        {
            var html = new StringBuilder();
            html.AppendLine("<ul>");

            foreach (var item in items)
            {
                html.AppendFormat(
                    ItemTemplate,
                    item.URL,
                    item.Category,
                    item.Title);
            }

            html.AppendLine("<ul>");
            return html.ToString();
        }
    }
}
