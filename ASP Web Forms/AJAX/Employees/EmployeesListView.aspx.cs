using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.UI;

namespace Employees
{
    public partial class EmployeesListView : Page
    {
        public NorthwindEntities dbContext;

        public EmployeesListView()
        {
            this.dbContext = new NorthwindEntities();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Employee> ListViewEmployees_GetData()
        {
            return this.dbContext.Employees.OrderBy(x => x.EmployeeID);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewEmployees_UpdateItem(int employeeID)
        {
            Employee item = dbContext.Employees.FirstOrDefault(x => x.EmployeeID == employeeID);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", employeeID));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                dbContext.SaveChanges();
            }
        }

        public void ListViewEmployees_InsertItem()
        {
            var item = new Employee();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                dbContext.SaveChanges();
            }
        }
    }
}