using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise_Computing_AdvancedDB1.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

// Jesse Baril & Austin Cameron

namespace Enterprise_Computing_AdvancedDB1
{
    public partial class Departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If loading page for the first time, populate the department grid, if not don't repopulate
            if (!IsPostBack)
            {
                Session["SortColumn"] = "DepartmentID"; // Default sort column
                Session["SortDirection"] = "ASC"; // Default sort direction
                // Get the Department data
                this.GetDepartments();
            }
        }

        /**
         * <summary>
         * This method gets the department data from the database
         * </summary>
         * @method GetDepartments
         * @return {void}
         * */
        protected void GetDepartments()
        {
            // Connect to EF
            using (ContosoConnection db = new ContosoConnection())
            {
                string SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();
                // Query the departments table using EF and LINQ
                var Departments = (from allDepartments in db.Departments select allDepartments);

                // Bind results to gridview
                DepartmentsGridView.DataSource = Departments.AsQueryable().OrderBy(SortString).ToList();
                DepartmentsGridView.DataBind();
            }
        }

        /**
         * <summary>
         * This method changes the amount of departments displayed per page when a different index is selected in the dropdown
         * </summary>
         * @method PageSizeDropDownList_SelectedIndexChanged
         * @param {object} sender
         * @param {EventArgs} e
         * @returns {void}
         * */
        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the new page size
            DepartmentsGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            // Refresh
            this.GetDepartments();
        }

        /**
         * <summary>
         * This event handler allows pagination for the departments page
         * </summary>
         * @method DepartmentsGridView_PageIndexChanging
         * @param {object} sender
         * @param {GridViewPageEventArgs} e
         * @returns {void}
         * */
        protected void DepartmentsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Set the new page number
            DepartmentsGridView.PageIndex = e.NewPageIndex;

            // Refresh the grid
            this.GetDepartments();
        }

        /**
         * <summary>
         * This event handler deletes a department from the databse using EF
         * </summary>
         * @method DepartmentsGridView_RowDeleting
         * @param {object} sender
         * @param {GridViewDeleteEventArgs}
         * @returns {void}
         * */
        protected void DepartmentsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Store which row was clicked
            int selectedRow = e.RowIndex;

            // Get the selected DepartmentID using the grids datakey collection
            int DepartmentID = Convert.ToInt32(DepartmentsGridView.DataKeys[selectedRow].Values["DepartmentID"]);

            // Use ef to find the selelcted Department and delete it
            using (ContosoConnection db = new ContosoConnection())
            {
                // Create object of the department class and store the query string inside of it
                Department deletedDepartment = (from departmentRecords in db.Departments
                                                where departmentRecords.DepartmentID == DepartmentID
                                                select departmentRecords).FirstOrDefault();

                // Remove the selected department from the db
                db.Departments.Remove(deletedDepartment);

                // Save db changes
                db.SaveChanges();

                // Refresh gridview
                this.GetDepartments();

            }
        }

        /**
         * <summary>
         * 
         * </summary>
         * @method DepartmentsGridView_Sorting
         * @param
         * @returns {void}
         * */
        protected void DepartmentsGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            // Get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            // Refresh the grid
            this.GetDepartments();

            // Toggle the direction from ASC and DSC
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DSC" : "ASC";
        }

        /**
         * <summary>
         * This method 
         * </summary>
         * @method DepartmentsGridView_RowDataBound
         * @param {object} sender
         * @param {GridViewRowEventArgs} e
         * @returns {void}
         * */
        protected void DepartmentsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)// If header row is clicked
                {
                    LinkButton linkButton = new LinkButton();

                    for (int index = 0; index < DepartmentsGridView.Columns.Count - 1; index++)
                    {
                        if (DepartmentsGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "ASC")
                            {
                                linkButton.Text = "<i class='fa fa-caret-up fa-lg'> </i>";
                            }
                            else
                            {
                                linkButton.Text = "<i class='fa fa-caret-down fa-lg'> </i>";
                            }

                            e.Row.Cells[index].Controls.Add(linkButton);
                        }
                    }
                }
            }
        }
    }
}