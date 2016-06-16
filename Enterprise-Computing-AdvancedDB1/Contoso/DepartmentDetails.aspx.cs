using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise_Computing_AdvancedDB1.Models;
using System.Web.ModelBinding;

// Jesse Baril & Austin Cameron

namespace Enterprise_Computing_AdvancedDB1
{
    public partial class DepartmentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetDepartment();
            }
        }

        protected void GetDepartment()
        {
            // Populate the form with existing data from the database
            int DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

            // Connect to the EF DB
            using (ContosoConnection db = new ContosoConnection())
            {
                // Populate a department object instance with the DepartmentID from the URL Parameter
                Department updatedDepartment = (from department in db.Departments
                                                where department.DepartmentID == DepartmentID
                                                select department).FirstOrDefault();

                // Map the department properties to the form controls
                if (updatedDepartment != null)
                {
                    DepartmentNameTextBox.Text = updatedDepartment.Name;
                    BudgetTextBox.Text = updatedDepartment.Budget.ToString();


                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to connect to the server
            using (ContosoConnection db = new ContosoConnection())
            {
                // Use the Departments model to create a new department object and
                // Save a new record
                Department newDepartment = new Department();

                int DepartmentID = 0;

                if (Request.QueryString.Count > 0) // URL has a DepartmentID in it
                {
                    // Get the id from the URL
                    DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                    // Get the current student from EF DB
                    newDepartment = (from department in db.Departments
                                     where department.DepartmentID == DepartmentID
                                     select department).FirstOrDefault();
                }

                // Add form data to the new department record
                newDepartment.Name = DepartmentNameTextBox.Text;
                newDepartment.Budget = Convert.ToDecimal(BudgetTextBox.Text);

                // Use LINQ to ADO.NET to add / insert new department into the database

                if (DepartmentID == 0)
                {
                    db.Departments.Add(newDepartment);
                }


                // Save changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated departments page
                Response.Redirect("~/Departments.aspx");
            }
        }


        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to Students page
            Response.Redirect("~/Departments.aspx");
        }
    }
}