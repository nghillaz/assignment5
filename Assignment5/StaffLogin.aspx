<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="Assignment5.StaffLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Author: Michael Zarate
        I don't really like the way the bootstrap table makes the lines but I don't really mind them either
        there are templates for login pages, but they require a bit of CSS which isn't really required at this stage -->
 <div class="row">
    <div class="col-md-8">
        <h1> Staff Login</h1>
        <h3> Please Login to continue</h3>
    </div> 
 </div>
    <div class="row">
        <div class="col-md-8">
            <table class="table">
                <tr>
                    <td> User Name:  </td>
                    <td> <asp:TextBox ID="StaffUserNameTextBox" runat="server" /></td>
                </tr>
                <tr>
                    <td> Password:   </td>
                    <td> <asp:TextBox ID="StaffPasswordTextBox" runat="server" /></td>
                </tr>
            </table>
            <asp:Label ID="Output" runat="server" />
            <br />
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginFunction" />         
            
        </div>
    </div>
</asp:Content>


<script language ="C#" runat="server">
    void LoginFunction(Object sender, EventArgs e)
    {

        //striaght from the book page 313 i hope to god this shit is right
        if (CustomAuthentication(StaffPasswordTextBox.Text, StaffPasswordTextBox.Text))
            FormsAuthentication.RedirectFromLoginPage(StaffPasswordTextBox.Text, false);
        else
            Output.Text = "Invalid login";
    }

    bool CustomAuthentication(string userName, string password)
    {
        string fileLocation = System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data/Staff.xml");

        if (System.IO.File.Exists(fileLocation))
        {
            System.Xml.XmlDocument StaffDoc = new System.Xml.XmlDocument();
            StaffDoc.Load(Server.MapPath("~/App_Data/Staff.xml"));
            System.Xml.XmlNodeList staffList = StaffDoc.SelectNodes("Staffers/Staff");

            //loop and try to find a maching set
            for(int i = 0; i <staffList.Count; i++)
            {
                if((staffList.Item(i).FirstChild.InnerText == userName) && (staffList.Item(i).LastChild.InnerText == password))
                {
                    return true;
                }
            }

        }
        return false;

    }




</script>


