using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserData"] != null && Request.Cookies["UserData"]["Username"] != null)
            {
                StaffUserNameTextBox.Text = Request.Cookies["UserData"]["Username"];
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

        }
    }
}