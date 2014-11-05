using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControls
{
    public partial class RandomNumber : Page
    {
        private static Random rand = new Random();
        
        protected void GetRandomNumber(object sender, EventArgs e)
        {
            int min;
            int max;
            if (int.TryParse(tbMin.Value, out min) && int.TryParse(tbMax.Value, out max))
            {
                if (min >= max)
                {
                    result.InnerText = "Max must be more than min!";
                }
                else
                {
                    result.InnerText = rand.Next(min, max + 1).ToString();
                }
            }
            else
            {
                result.InnerText = "Invalid ranges!";
            }
        }

        protected void BtnRandomWebClick(object sender, EventArgs e)
        {
            int min;
            int max;
            if (int.TryParse(tbMinWeb.Text, out min) && int.TryParse(tbMaxWeb.Text, out max))
            {
                if (min >= max)
                {
                    resultWeb.Text = "Max must be more than min!";
                }
                else
                {
                    resultWeb.Text = rand.Next(min, max + 1).ToString();
                }
            }
            else
            {
                resultWeb.Text = "Invalid ranges!";
            }
        }
    }
}