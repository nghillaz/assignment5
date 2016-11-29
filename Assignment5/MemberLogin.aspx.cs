using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

//WRITTEN BY NATHAN HILL

namespace Assignment5.Member
{
    public partial class MemberLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if they registered or logged in recently, remember their name
                if (Request.Cookies["UserData"] != null && Request.Cookies["UserData"]["Username"] != null)
                {
                    UsernameTextBox.Text = Request.Cookies["UserData"]["Username"];
                }
            }
        }

        protected void LoginButtonClick(object sender, EventArgs e)
        {
            //check for empty text boxes
            if (UsernameTextBox.Text.Length == 0)
            {
                StatusLabel.Text = "Enter a username";
                StatusLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (PasswordTextBox.Text.Length == 0)
            {
                StatusLabel.Text = "Enter a password";
                StatusLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            //open the xml document and check if user exists
            //if so, sign them in and start their session
            XmlDocument membersXML = new XmlDocument();
            membersXML.Load(Server.MapPath("~/App_Data/Member.xml"));
            XmlNodeList membersList = membersXML.SelectNodes("Members/Member");
            for (int i = 0; i < membersList.Count; i++)
            {
                if (membersList.Item(i).FirstChild.InnerText == UsernameTextBox.Text && membersList.Item(i).LastChild.InnerText == ExtraFunctions.HashFunction(PasswordTextBox.Text).ToString())
                {
                    Session["Username"] = UsernameTextBox.Text;
                    Session["Sid"] = Session.SessionID;
                    Session["IsAdmin"] = "false";
                    Response.Redirect("Member/Member");
                }
            }
        }
    }
}