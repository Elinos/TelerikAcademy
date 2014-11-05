using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Cookies
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Logged"] != null)
            {
                Response.Redirect("~/Home.aspx");
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("Logged", "You are logged in!");
            cookie.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Add(cookie);
            Response.Redirect("~/Home.aspx");
        }
    }
}