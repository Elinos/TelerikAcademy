using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SummatorInASPWebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSum_Click(object sender, EventArgs e)
        {
            var firstNumber = int.Parse(tbFirstNumber.Text);
            var secondNumber = int.Parse(tbSecondNumber.Text);
            tbResult.Text = (firstNumber + secondNumber).ToString();
        }
    }
}