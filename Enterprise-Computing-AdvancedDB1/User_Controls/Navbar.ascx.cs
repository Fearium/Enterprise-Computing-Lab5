using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Required for Identity and OWIN Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

/**
 * @author: Jesse Baril
 * @date: June 2nd, 2016
 * @version: 0.0.2 - updated SetActivePage method to include new links
 */

namespace Enterprise_Computing_AdvancedDB1
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    ContosoPlaceHolder.Visible = true;
                    PublicPlaceHolder.Visible = false;

                    if(HttpContext.Current.User.Identity.GetUserName() == "admin")
                    {
                        UserPlaceHolder.Visible = true;
                    }
                }
                else
                {
                    ContosoPlaceHolder.Visible = false;
                    PublicPlaceHolder.Visible = true;
                    UserPlaceHolder.Visible = false;
                }
                SetActivePage();
            }
            
        }

        /**
         * This method adds a css class of "active" to list items
         * relating to the current page
         * 
         * @private
         * @method SetActivePage
         * @return {void}
         */
        private void SetActivePage()
        {
            switch (Page.Title)
            {
                case "Home Page":
                    home.Attributes.Add("class", "active");
                    break;
                case "Students":
                    students.Attributes.Add("class", "active");
                    break;
                case "Courses":
                    courses.Attributes.Add("class", "active");
                    break;
                case "Departments":
                    departments.Attributes.Add("class", "active");
                    break;
                case "Contact":
                    contact.Attributes.Add("class", "active");
                    break;
                case "Login":
                    login.Attributes.Add("class", "active");
                    break;
                case "Register":
                    register.Attributes.Add("class", "active");
                    break;
                case "Contoso Menu":
                    menu.Attributes.Add("class", "active");
                    break;
                case "Logout":
                    logout.Attributes.Add("class", "active");
                    break;
                case "Users":
                    users.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}