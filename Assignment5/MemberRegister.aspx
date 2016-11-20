<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberRegister.aspx.cs" Inherits="Assignment5.Member.MemberRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- WRITTEN BY NATHAN HILL --%>
    <h1>Member Registration</h1>
    <h2>Username: <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox></h2>
    <h2>Password: <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox></h2>
    <asp:Image ID="ImageVerifierImage" runat="server" /> <asp:Button ID="ReloadVerification" OnClientCli="return false;" OnClick="ReloadVerification_Click" runat="server" Text="get new image" />
    <p>Enter verification text below:</p>
    <p>
    <asp:TextBox ID="ImageVerifierTextBox" runat="server"></asp:TextBox>
    </p>
    <h2><asp:Button ID="Button1" runat="server" OnClick="RegisterButtonClick" Text="Register" /></h2>
    <h3><asp:Label ID="StatusLabel" runat="server" Text=""></asp:Label></h3>
</asp:Content>
