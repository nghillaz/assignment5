using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Library;

namespace Assignment5.Member
{
    public partial class MemberRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButtonClick(object sender, EventArgs e)
        {
            if(UsernameTextBox.Text.Length == 0)
            {
                StatusLabel.Text = "Enter a username";
                StatusLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if(PasswordTextBox.Text.Length == 0)
            {
                StatusLabel.Text = "Enter a password";
                StatusLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            XmlDocument membersXML = new XmlDocument();
            membersXML.Load(Server.MapPath("~/App_Data/Member.xml"));
            XmlNodeList membersList = membersXML.SelectNodes("Members/Member");
            for(int i = 0; i < membersList.Count; i++)
            {
                if(membersList.Item(i).FirstChild.InnerText == UsernameTextBox.Text)
                {
                    StatusLabel.Text = "Username already exists";
                    StatusLabel.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }

            XmlElement newMember = membersXML.CreateElement("Member");
            XmlElement newMemberUserName = membersXML.CreateElement("UserName");
            XmlElement newMemberPassword = membersXML.CreateElement("Password");
            newMemberUserName.InnerText = UsernameTextBox.Text;

            newMemberPassword.InnerText = ExtraFunctions.HashFunction(PasswordTextBox.Text).ToString();
            newMember.AppendChild(newMemberUserName);
            newMember.AppendChild(newMemberPassword);
            membersXML.DocumentElement.AppendChild(newMember);
            membersXML.Save(Server.MapPath("~/App_Data/Member.xml"));

            StatusLabel.Text = "User created";
            StatusLabel.ForeColor = System.Drawing.Color.Black;
        }
    }
}