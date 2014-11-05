using System;
using System.Linq;

namespace Browser
{
    public partial class Browser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelBrowser.Text = Request.Browser.Type;
            this.LabelIpAddress.Text = Request.UserHostAddress;
        }
    }
}