using NewsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace NewsSystem
{
    public class BasePage : Page
    {
        public NewsSystemDbContext dbContext;

        public BasePage()
        {
            this.dbContext = new NewsSystemDbContext();
        }
    }
}
