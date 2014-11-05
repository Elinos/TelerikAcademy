using System;
using System.Collections.Generic;
using System.Linq;

namespace SavedText
{
    public partial class SavedText : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["Messages"] == null)
            {
                Session["Messages"] = new List<string>();
            }
            else
            {
                LabelOutput.Text = String.Join("<br />", (List<string>)Session["Messages"]);
            }
        }

        protected void ButtonEnter_Click(object sender, EventArgs e)
        {
            ((List<string>)Session["Messages"]).Add(this.TextBoxInput.Text);
        }
    }
}