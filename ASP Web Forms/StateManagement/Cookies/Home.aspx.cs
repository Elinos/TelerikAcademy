using System;
using System.Linq;
using System.Web.UI;

namespace Cookies
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Logged"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}