using System;
using System.Linq;
using System.Web.UI;

namespace WebFormsIntro
{
    public partial class _Default : Page
    {
        public void ButtonSayHello_Click(object sender, EventArgs e)
        {
            this.LabelGreeting.Text = "Hello, " + this.TextBoxName.Text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}