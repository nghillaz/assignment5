using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Library;

//WRITTEN BY NATHAN HILL

namespace Assignment5
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //generate the members xml file with no members
            if (!File.Exists(Server.MapPath("~/App_Data/Member.xml")))
            {
                File.WriteAllText(Server.MapPath("~/App_Data/Member.xml"), "<Members></Members>");
            }

            //Zarate started writing here!
            //We also need to create an XML file for Staff
            if(!File.Exists(Server.MapPath("~/App_Data/Staff.xml")))
            {
                File.WriteAllText(Server.MapPath("~/App_Data/Staff.xml"), "<Staffers></Staffers>");
                initStaffCredintials();
            }
           
        }

        //Author: Zarate
        void initStaffCredintials()
        {
            //get the file location first
            string fileLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            fileLocation = Path.Combine(fileLocation, "Staff.xml");


            string adminPassword = ZarateHash.HashFunction("password").ToString();
            string taPassword = ZarateHash.HashFunction("CSE445598ta!").ToString();


            //load the file
            XDocument doc = XDocument.Load(fileLocation);
            //write to the file and save
            XElement newStaff = doc.Element("Staffers");
            newStaff.Add(new XElement("Staff",
                         new XElement("UserName", "admin"),
                         new XElement("Password", adminPassword)));
            newStaff.Add(new XElement("Staff",
                         new XElement("UserName", "TA"),
                         new XElement("Password", taPassword)));
            doc.Save(fileLocation);
        }
    }
}