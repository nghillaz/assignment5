using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MemberPageButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("Member/Member");
        }

        protected void MemberRegisterButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("MemberRegister");
        }

        protected void MemberLoginButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("MemberLogin");
        }

        protected void StaffLoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffLogin");
        }

        protected void StaffPageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Staff/Staff");
        }
    }
}