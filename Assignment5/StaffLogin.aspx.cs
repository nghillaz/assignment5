﻿using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

//Author Zarate
namespace Assignment5
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserData"] != null && Request.Cookies["UserData"]["Username"] != null)
                {
                    StaffUserNameTextBox.Text = Request.Cookies["UserData"]["Username"];
                }
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //check against empty boxes
            if(StaffUserNameTextBox.Text.Length == 0)
            {
                Output.Text = "Please Enter a user name";
                return;
            }
            if(StaffPasswordTextBox.Text.Length == 0)
            {
                Output.Text = "Please enter your password";
                return;
            }

            //open our xml document where our username and paswords are stored
            XmlDocument staffDoc = new XmlDocument();
            staffDoc.Load(Server.MapPath("~/App_Data/Staff.xml"));
            XmlNodeList staffList = staffDoc.SelectNodes("Staffers/Staff");

            //go look for a user and log them in 
            for (int i = 0; i <staffList.Count; i++)
            {
                if ((staffList.Item(i).FirstChild.InnerText == StaffUserNameTextBox.Text) 
                    && (staffList.Item(i).LastChild.InnerText 
                    == ZarateHash.HashFunction(StaffPasswordTextBox.Text).ToString()))
                {
                    //add username to cookies for easier logging in in the future
                    if (Response.Cookies["UserData"] != null & Response.Cookies["UserData"]["Username"] != null)
                    {
                        Response.Cookies["UserData"]["Username"] = StaffUserNameTextBox.Text;
                    }
                    else
                    {
                        HttpCookie usernameCookie = new HttpCookie("UserData");
                        usernameCookie["Username"] = StaffUserNameTextBox.Text;
                        usernameCookie.Expires = DateTime.Now.AddDays(1d);
                        Response.Cookies.Add(usernameCookie);
                    }

                    Session["Username"] = StaffUserNameTextBox.Text;
                    Session["Sid"] = Session.SessionID;
                    Session["isAdmin"] = "true";
                    Response.Redirect("Staff/Staff");
                }
                else
                {
                    Output.Text = "Invalid Login could not authenticate";
                }
            }
        }
    }
}