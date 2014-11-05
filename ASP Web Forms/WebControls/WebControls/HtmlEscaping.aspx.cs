using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControls
{
    public partial class HtmlEscaping : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void tbOne_TextChanged(object sender, EventArgs e)
        {
            var text = tbOne.Text;
            tbResult.Text = text;
            lblResult.Text = Server.HtmlEncode(text);
        }
    }
}