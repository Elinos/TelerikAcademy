using LikesDemo.Controls;
using Microsoft.AspNet.Identity;
using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSystem
{
    public partial class ArticleDetails : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public NewsSystem.Models.Article FormViewArticleDetails_GetItem([QueryString("id")]int? articleID)
        {
            if (articleID == null)
            {
                Response.Redirect("~/");
            }

            var article = this.dbContext.Articles.Include("Category").Include("Author").FirstOrDefault(a => a.ID == articleID);
            return article;
        }

        protected int GetLikesValue(Article item)
        {
            int likesCount = item.Likes.Count(l => l.Value == true);
            int hatesCount = item.Likes.Count(l => l.Value == false);
            return likesCount - hatesCount;
        }

        protected bool? GetUserVote(Article item)
        {
            string userID = this.User.Identity.GetUserId();
            var like = item.Likes.FirstOrDefault(l => l.UserID == userID);
            if (like == null)
            {
                return null;
            }

            return like.Value;
        }

        protected void LikeControl_Like(object sender, LikeEventArgs e)
        {
            Article article = this.dbContext.Articles.Find(Convert.ToInt32(e.DataID));
            string userID = this.User.Identity.GetUserId();

            Like like = article.Likes.FirstOrDefault(l => l.UserID == userID);
            if (like == null)
            {
                like = new Like()
                {
                    UserID = userID,
                    ArticleID = Convert.ToInt32(e.DataID)
                };

                article.Likes.Add(like);
            }

            like.Value = e.LikeValue;
            this.dbContext.SaveChanges();

            //LikeControl ctrl = sender as LikeControl;
            DataBind();
        }
    }
}