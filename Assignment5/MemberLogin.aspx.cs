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

        }

        protected void LoginButtonClick(object sender, EventArgs e)
        {
            {
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

                XmlDocument membersXML = new XmlDocument();
                membersXML.Load(Server.MapPath("~/App_Data/Member.xml"));
                XmlNodeList membersList = membersXML.SelectNodes("Members/Member");
                for (int i = 0; i < membersList.Count; i++)
                {
                    if (membersList.Item(i).FirstChild.InnerText == UsernameTextBox.Text && membersList.Item(i).LastChild.InnerText == ExtraFunctions.HashFunction(PasswordTextBox.Text).ToString())
                    {
                        Session["Username"] = UsernameTextBox.Text;
                        Session["Sid"] = Session.SessionID;
                        Response.Redirect("Member/Member");
                    }
                }
            }
        }
    }
}