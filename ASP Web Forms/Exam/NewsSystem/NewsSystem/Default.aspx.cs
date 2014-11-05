using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem
{
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Article> ListViewArticles_GetData()
        {
            return this.dbContext.Articles.Include("Author").Include("Category").OrderByDescending(a => a.Likes.Count).Take(3);
        }

        public static string Truncate(string input, int characterLimit)
        {
            string output = input;

            // Check if the string is longer than the allowed amount otherwise do nothing.
            if (output.Length > characterLimit && characterLimit > 0)
            {
                // Cut the string down to the maximum number of characters.
                output = output.Substring(0, characterLimit);

                // Check if the character right after the truncate point was a space
                // if not, we are in the middle of a word and need to remove the rest of it
                if (input.Substring(output.Length, 1) != " ")
                {
                    int LastSpace = output.LastIndexOf(" ");

                    // If we found a space then, cut back to that space.
                    if (LastSpace != -1)
                    {
                        output = output.Substring(0, LastSpace);
                    }
                }
                // Finally, add the "..."
                output += "...";
            }
            return output;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<NewsSystem.Models.Category> ListViewCategories_GetData()
        {
            return this.dbContext.Categories.Include("Articles");
        }

        protected IList<Article> GetArticles(int categoryID)
        {
            return this.dbContext.Articles.Include("Category").Include("Author")
                       .Where(a => a.CategoryID == categoryID)
                       .OrderByDescending(a => a.DateCreated).Take(3).ToList();
        }
    }
}