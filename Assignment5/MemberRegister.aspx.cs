using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Library;

//WRITTEN BY NATHAN HILL

namespace Assignment5.Member
{
    public partial class MemberRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //generate an image of length 5 for verification
            if (!IsPostBack)
            {
                ImageVerifierService.Service verifierService = new ImageVerifierService.Service();
                Session["verifyString"] = verifierService.GetVerifierString("5");
                ImageVerifierImage.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(verifierService.GetImage(Session["verifyString"].ToString()));
            }
        }

        protected void RegisterButtonClick(object sender, EventArgs e)
        {
            //check image verifier
            if(Session["verifyString"] != null && !Session["verifyString"].ToString().ToLower().Equals(ImageVerifierTextBox.Text.ToLower()))
            {
                StatusLabel.Text = "Image verification not correct";
                StatusLabel.ForeColor = System.Drawing.Color.Red;
                return;
            }

            //check if textboxes are empty
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

            //check if username is already in the xml file
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

            //create a new user in the file
            XmlElement newMember = membersXML.CreateElement("Member");
            XmlElement newMemberUserName = membersXML.CreateElement("UserName");
            XmlElement newMemberPassword = membersXML.CreateElement("Password");
            newMemberUserName.InnerText = UsernameTextBox.Text;
            //hash the password
            newMemberPassword.InnerText = ExtraFunctions.HashFunction(PasswordTextBox.Text).ToString();
            newMember.AppendChild(newMemberUserName);
            newMember.AppendChild(newMemberPassword);
            membersXML.DocumentElement.AppendChild(newMember);
            membersXML.Save(Server.MapPath("~/App_Data/Member.xml"));
            StatusLabel.Text = "User created";
            StatusLabel.ForeColor = System.Drawing.Color.Black;

            //add username to cookies for easier logging in in the future
            if(Response.Cookies["UserData"] != null & Response.Cookies["UserData"]["Username"] != null)
            {
                Response.Cookies["UserData"]["Username"] = UsernameTextBox.Text;
            }
            else
            {
                HttpCookie usernameCookie = new HttpCookie("UserData");
                usernameCookie["Username"] = UsernameTextBox.Text;
                usernameCookie.Expires = DateTime.Now.AddDays(1d);
                Response.Cookies.Add(usernameCookie);
            }
        }

        //in case the image is too hard to read
        protected void ReloadVerification_Click(object sender, EventArgs e)
        {
            ImageVerifierService.Service verifierService = new ImageVerifierService.Service();
            Session["verifyString"] = verifierService.GetVerifierString("8");
            ImageVerifierImage.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(verifierService.GetImage(Session["verifyString"].ToString()));
        }
    }
}