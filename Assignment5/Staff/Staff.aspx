<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Assignment5.Staff.Staff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <div class="row">
        <div class="col-md-8">
            <h2> Welcome to the Staff Page</h2>
            <br />
            <p>
                <% Response.Write("Hello" + Context.User.Identity.Name + ","); %>
                This page contains information for only staff members. <br />
                AUTHORIZED STAFF MEMBERS ONLY!
            </p>
        </div>
    </div>

</asp:Content>
