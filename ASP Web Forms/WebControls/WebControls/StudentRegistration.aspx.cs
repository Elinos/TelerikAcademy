using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControls
{
    public partial class StudentRegistration : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            var firstName = tbFirstName.Text;
            var lastName = tbLastName.Text;
            var facultyNumber = tbFacultyNumber.Text;
            var university = ddlUniversity.SelectedValue;
            var specialty = ddlSpecialty.SelectedValue;
            var courses = new List<string>();
            foreach (ListItem course in lbCourses.Items)
            {
                if (course.Selected)
                {
                    courses.Add(course.Value);
                }
            }
            ShowSummary(firstName, lastName, facultyNumber, university, specialty, courses);
        }
 
        private void ShowSummary(string firstName, string lastName, string facultyNumber, string university, string specialty, List<string> courses)
        {
            var panel = panelSummary;
            panel.Controls.Add(new LiteralControl("<h1>Student Info: </h1>"));

            panel.Controls.Add(new LiteralControl("<strong>Student Name: </strong>"));
            var fullName = new Literal();
            fullName.Text = String.Format("{0} {1}", firstName, lastName);
            panel.Controls.Add(fullName);
            panel.Controls.Add(new LiteralControl("<br />"));
            
            panel.Controls.Add(new LiteralControl("<strong>Faculty Number: </strong>"));
            panel.Controls.Add(new Literal { Text = facultyNumber });
            panel.Controls.Add(new LiteralControl("<br />"));

            panel.Controls.Add(new LiteralControl("<strong>University: </strong>"));
            panel.Controls.Add(new Literal { Text = university });
            panel.Controls.Add(new LiteralControl("<br />"));

            panel.Controls.Add(new LiteralControl("<strong>Specialty: </strong>"));
            panel.Controls.Add(new Literal { Text = specialty });
            panel.Controls.Add(new LiteralControl("<br />"));
            
            panel.Controls.Add(new LiteralControl("<strong>Courses: </strong>"));
            panel.Controls.Add(new Literal { Text = String.Join(", ", courses) });
        }
    }
}