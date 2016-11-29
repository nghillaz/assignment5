<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Assignment5.Member.Member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- WRITTEN BY NATHAN HILL --%>
    <div class="row">
        <div class="col-md-8">
            <h2> Welcome to the Member Page, <asp:Label ID="UsernameLabel" runat="server" Text=""></asp:Label></h2>
            <h5>You have access to the following tools!</h5>
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            <h4>Get Local Weather via WeatherService!</h4>
            <p>
                Find the local weather!<br />
                Enter in the zipcode you want the weather for: 
                <asp:TextBox ID="WeatherZipCodeTextBox" runat="server"></asp:TextBox><br />
                Enter in the Units([case sensitive] imperial or  metric):
                <asp:TextBox ID="WeatherUnitsTextBox" runat="server"></asp:TextBox> <br /> 
                <asp:Button ID="GetWeatherButton" runat="server" Text="Get Weather" OnClick="WeatherButton_Click" />
                <br />
                <asp:Label ID="ForcastLabel" runat="server" Text=""></asp:Label>
                <br />
                <br />
                FOR The Area OF: 
                <asp:Label ID="LocationOutLabel" runat="server" Text=""></asp:Label>
        </p>
        </div>
    </div>
</asp:Content>
