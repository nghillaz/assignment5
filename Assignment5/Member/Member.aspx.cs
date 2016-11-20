using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//WRITTEN BY NATHAN HILL

namespace Assignment5.Member
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Sid"] == null)
            {
                Response.Redirect("~/MemberLogin");
            }
            else
            {
                UserNameLabel.Text = Session["Username"].ToString();
            }
        }
    }
}