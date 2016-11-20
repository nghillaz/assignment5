<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment5._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Author: Michael Zarate -->
    <div class="jumbotron">
        <h1>WebApp</h1>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Member Login Landing</h2>
                <asp:Button ID="MemberRegisterButton" runat="server" OnClick="MemberRegisterButtonClick" Text="Member Registration" />  
                <asp:Button ID="MemberLoginButton" runat="server" OnClick="MemberLoginButtonClick" Text="Member Login" />           
        </div>
        <div class="col-md-4">
            <h2>Staff Login Landing</h2>
                 <asp:Button ID="StaffPageButton" runat="server" Text="Staff Page" /> 
                 <asp:Button ID="StaffLoginButton" runat="server" Text="Staff Login" OnClick="StaffLoginButton_Click"/> 
        </div>
        <div class="col-md-4">
            <h2>Public Pages Landing</h2>
            <asp:Button ID="PublicPageButton" runat="server" Text="Learn More" />
            <!-- Maybe have this redirect to an about page to discribe how the web site works? -->
       </div> 
               
    </div>

</asp:Content>

