using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewsSystem.Helpers;
using NewsSystem.Models;
using Microsoft.AspNet.Identity;
using Error_Handler_Control;

namespace NewsSystem.Admin
{
    public partial class Articles : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        public IQueryable<Article> ListViewArticles_GetData([ViewState("OrderBy")]
                                                            String orderBy = null)
        {
            var articles = this.dbContext.Articles.Include("Category").Include("Author").OrderBy(b => b.ID);

            if (orderBy != null)
            {
                switch (this.SortDirection)
                {
                    case SortDirection.Ascending:
                        articles = articles.OrderByDescending(orderBy);
                        break;
                    case SortDirection.Descending:
                        articles = articles.OrderBy(orderBy);
                        break;
                    default:
                        articles = articles.OrderByDescending(orderBy);
                        break;
                }
            }
            return articles;
        }

        protected void ListViewArticles_Sorting(object sender, ListViewSortEventArgs e)
        {
            e.Cancel = true;
            ViewState["OrderBy"] = e.SortExpression;
            this.ListViewArticles.DataBind();
        }

        public SortDirection SortDirection
        {
            get
            {
                if (ViewState["sortdirection"] == null)
                {
                    ViewState["sortdirection"] = SortDirection.Ascending;
                    return SortDirection.Ascending;
                }
                else if ((SortDirection)ViewState["sortdirection"] == SortDirection.Ascending)
                {
                    ViewState["sortdirection"] = SortDirection.Descending;
                    return SortDirection.Descending;
                }
                else
                {
                    ViewState["sortdirection"] = SortDirection.Ascending;
                    return SortDirection.Ascending;
                }
            }
            set
            {
                ViewState["sortdirection"] = value;
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewArticles_UpdateItem(int ID)
        {
            Article item = this.dbContext.Articles.FirstOrDefault(x => x.ID == ID);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", ID));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.dbContext.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Article updated!");
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewArticles_DeleteItem(int ID)
        {
            var item = this.dbContext.Articles.FirstOrDefault(c => c.ID == ID);
            foreach (var like in item.Likes.ToList())
            {
                this.dbContext.Likes.Remove(like);
            }
            this.dbContext.Articles.Remove(item);

            this.dbContext.SaveChanges();
            ErrorSuccessNotifier.AddSuccessMessage("Article deleted!");
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

        public IEnumerable<Category> GetCategories()
        {
            return this.dbContext.Categories.AsEnumerable();
        }

        public void FormViewIsertArticle_InsertItem()
        {
            var item = new Article();
            item.AuthorID = this.User.Identity.GetUserId();
            item.DateCreated = DateTime.Now;
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.dbContext.Articles.Add(item);
                this.dbContext.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Article created!");
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                Response.Redirect("~/Admin/Articles.aspx");
            }
        }

        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {
            this.LinkButtonInsert.Attributes.Add("style", "display:none");
            
            var fv = this.UpdatePanelInsertArticle.FindControl("FormViewInsertArticle") as FormView;
            fv.Visible = true;
        }

        public IQueryable<Category> DropDownListCategoriesCreate_GetData()
        {
            return this.dbContext.Categories.OrderBy(b => b.Name);
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            var textBoxTitle = this.ListViewArticles.EditItem.FindControl("tbTitleEdit") as TextBox;
            var textBoxContent = this.ListViewArticles.EditItem.FindControl("tbContentEdit") as TextBox;
            if (string.IsNullOrEmpty(textBoxTitle.Text))
            {
                ErrorSuccessNotifier.AddErrorMessage("Title is required!");
                Response.Redirect(Request.RawUrl);
            }
            if (string.IsNullOrEmpty(textBoxContent.Text))
            {
                ErrorSuccessNotifier.AddErrorMessage("Content is required!");
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void LinkButtonCreate_Click(object sender, EventArgs e)
        {
            var textBoxTitle = this.FormViewInsertArticle.FindControl("TextBoxArticleTitleCreate") as TextBox;
            var textBoxContent = this.FormViewInsertArticle.FindControl("TextBoxContentCreate") as TextBox;
            if (string.IsNullOrEmpty(textBoxTitle.Text))
            {
                ErrorSuccessNotifier.AddErrorMessage("Title is required!");
                Response.Redirect(Request.RawUrl);
            }
            if (string.IsNullOrEmpty(textBoxContent.Text))
            {
                ErrorSuccessNotifier.AddErrorMessage("Content is required!");
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}