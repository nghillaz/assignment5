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
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
            
        </div>
    </div>
</asp:Content>

