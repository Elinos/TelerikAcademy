using Error_Handler_Control;
using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem.Admin
{
    public partial class Categories : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Category> ListViewCategories_GetData()
        {
            return this.dbContext.Categories.OrderBy(x => x.ID);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategories_UpdateItem(int ID)
        {
            Category item = this.dbContext.Categories.FirstOrDefault(x => x.ID == ID);
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
                ErrorSuccessNotifier.AddSuccessMessage("Category updated!");
            }
        }

        public void ListViewCategories_InsertItem()
        {
            var name = (this.ListViewCategories.InsertItem.FindControl("tbName") as TextBox).Text;
            var item = new Category()
            {
                Name = name
            };
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.dbContext.Categories.Add(item);
                this.dbContext.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Category inserted!");
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategories_DeleteItem(int ID)
        {
            var item = this.dbContext.Categories.FirstOrDefault(c => c.ID == ID);
            foreach (var article in item.Articles.ToList())
            {
                foreach (var like in article.Likes.ToList())
                {
                    this.dbContext.Likes.Remove(like);
                }
                this.dbContext.Articles.Remove(article);
            }
            this.dbContext.Categories.Remove(item);

            this.dbContext.SaveChanges();
            ErrorSuccessNotifier.AddSuccessMessage("Category deleted!");
        }
        
        protected void EditButton_Click(object sender, EventArgs e)
        {
            var textBoxName = this.ListViewCategories.EditItem.FindControl("tbNameEdit") as TextBox;
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                ErrorSuccessNotifier.AddErrorMessage("Name is required!");
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            var textBoxName = this.ListViewCategories.InsertItem.FindControl("tbName") as TextBox;
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                ErrorSuccessNotifier.AddErrorMessage("Name is required!");
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}