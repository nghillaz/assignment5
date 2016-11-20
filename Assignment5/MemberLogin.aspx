<%@ Page Title="Member Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberLogin.aspx.cs" Inherits="Assignment5.Member.MemberLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Member Login</h1>
    <h2>Username: <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox></h2>
    <h2>Password: <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox></h2>
    <h2><asp:Button ID="Button1" runat="server" OnClick="LoginButtonClick" Text="Login" /></h2>
    <h3><asp:Label ID="StatusLabel" runat="server" Text=""></asp:Label></h3>
</asp:Content>
