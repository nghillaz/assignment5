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
            //user has no session, needs to login, send them to that page
            if(Session["Sid"] == null)
            {
                Response.Redirect("~/MemberLogin");
            }
            //if the user has a session, they've successfully logged in and should be allowed on the page
            //also display their username at the top of the page
            else
            {
                UserNameLabel.Text = "Welcome back, " + Session["Username"].ToString();
            }
        }
    }
}