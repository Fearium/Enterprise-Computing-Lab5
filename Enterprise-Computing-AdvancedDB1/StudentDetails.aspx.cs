using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Using statements required for EF DB acess
using Enterprise_Computing_AdvancedDB1.Models;
using System.Web.ModelBinding;

namespace Enterprise_Computing_AdvancedDB1
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetStudent();
            }
        }

        protected void GetStudent()
        {
            // Populate the form with existing data from the database
            int StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

            // Connect to the EF DB
            using (ContosoConnection db = new ContosoConnection())
            {
                // Populate a student object instance with the StudentId from the URL parameter
                Student updatedStudent = (from student in db.Students
                                          where student.StudentID == StudentID
                                          select student).FirstOrDefault();

                // Map the student properties to the form controls
                if (updatedStudent != null)
                {
                    LastNameTextBox.Text = updatedStudent.LastName;
                    FirstNameTextBox.Text = updatedStudent.FirstMidName;
                    EnrollmentDateTextBox.Text = updatedStudent.EnrollmentDate.ToString("yyyy-MM-dd");
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to Students Page
            Response.Redirect("~/Students.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to connect to the server
            using (ContosoConnection db = new ContosoConnection())
            {
                // Use the Student model to create a new student object and save a new record
                Student newStudent = new Student();

                int StudentID = 0;

                if (Request.QueryString.Count > 0) // Our URL has a StudentID in it
                {
                    // Get the ID from the URL
                    StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    // Get the current student from EF DB
                    newStudent = (from student in db.Students
                                  where student.StudentID == StudentID
                                  select student).FirstOrDefault();
                }
                // Add data to the new student record
                newStudent.LastName = LastNameTextBox.Text;
                newStudent.FirstMidName = FirstNameTextBox.Text;
                newStudent.EnrollmentDate = Convert.ToDateTime(EnrollmentDateTextBox.Text);

                // Use LINQ to ADO.NET to add or insert new student into the database
                if (StudentID == 0)
                {
                    db.Students.Add(newStudent);
                }

                // Save our changes
                db.SaveChanges();

                // Redirect back to the updated students page
                Response.Redirect("~/Students.aspx");
            }
        }
    }
}